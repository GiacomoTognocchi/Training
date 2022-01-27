using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System;
using System.Threading;
using CC.Business.ProfileManager.Core.CribisComX.ProfileOverride;

namespace CC.Business.ProfileManager.Core.CribisComX {
    public static class ProfileStore<T> where T : class {
        private static readonly Dictionary<string, ProfileManager<T>> vProfileManagers = new Dictionary<string, ProfileManager<T>>();

        private static readonly object lockRoot = new object();
        
        // Explicit type initializer to instruct C# compiler not to mark the type with BeforeFieldInit flag
        static ProfileStore() {
        }

        public static ProfileManager<T> GetProfileManager(string connectionString) {
            ProfileManager<T> ret = null;
            if (!vProfileManagers.ContainsKey(connectionString)) {
                lock (lockRoot) {
                    if (!vProfileManagers.ContainsKey(connectionString)) {
                        vProfileManagers.Add(connectionString, new ProfileManager<T>(connectionString));
                    }
                }
            }
            ret = vProfileManagers[connectionString];
            return ret;
        }
    }
    
    public class ProfileManager<T> where T : class {
        const int LOCKDELAY = 10000;

        private readonly ReaderWriterLock lockRoot = new ReaderWriterLock();

        private readonly string connectionString = "";

        private readonly Dictionary<ProfileKey, T> vProfiles = new Dictionary<ProfileKey, T>();

        private readonly Dictionary<ProfileKey, ProfileTimer> vExpiryTimes = new Dictionary<ProfileKey, ProfileTimer>();

        // Explicit type initializer to instruct C# compiler not to mark the type with BeforeFieldInit flag
        static ProfileManager() {
        }

        internal ProfileManager(string connectionString) {
            this.connectionString = connectionString;
        }

        public T GetProfile(string hierarchyDN, string channel, string key) {
            T ret = default(T);
            ProfileKey profileKey = new ProfileKey(hierarchyDN, channel, key);
            LockCookie lockCookie;
            lockRoot.AcquireReaderLock(LOCKDELAY);
            try {
                if (!vProfiles.ContainsKey(profileKey)) {
                    lockCookie = lockRoot.UpgradeToWriterLock(LOCKDELAY);
                    try {
                        if (!vProfiles.ContainsKey(profileKey)) {
                            AddProfile(profileKey);
                        }
                    }
                    finally {
                        lockRoot.DowngradeFromWriterLock(ref lockCookie);
                    }
                }
                else {
                    vExpiryTimes[profileKey].Renew();
                }
                ret = vProfiles.ContainsKey(profileKey) ? vProfiles[profileKey] : default(T);
            }
            finally {
                lockRoot.ReleaseReaderLock();
            }

            //TODO: capire come gestire la cache con Muzzi
            RemoveProfile(profileKey);

            return ret;
        }

        /// <summary>
        /// It works as GetProfile but removes value from cache before reads
        /// </summary>
        /// <param name="hierarchyDN"></param>
        /// <param name="channel"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public T ReloadProfile(string hierarchyDN, string channel, string key)
        {
            // Remove profile from cache
            ProfileKey profileKey = new ProfileKey(hierarchyDN, channel, key);
            RemoveProfile(profileKey);
            
            // load profile
            return GetProfile(hierarchyDN, channel, key);
        }

        /// <summary>
        /// Sets Profile Overrides for a user profilation
        /// </summary>
        /// <param name="hierarchyDN">The user full name to profile</param>
        /// <param name="channel">The user channel</param>
        /// <param name="key">The profile object namespace</param>
        /// <param name="profilation">The Profile Overrides object</param>
        /// <returns>Returns true when the method is successful</returns>
        [Obsolete]
        public bool SetProfilation(string hierarchyDN, string channel, string key, PO profilation)
        {
            return SetProfilationOverride(hierarchyDN, channel, key, profilation);
        }

        /// <summary>
        /// Sets Profile Overrides for a user profilation
        /// </summary>
        /// <param name="hierarchyDN">The user full name to profile</param>
        /// <param name="channel">The user channel</param>
        /// <param name="key">The profile object namespace</param>
        /// <param name="profilation">The Profile Overrides object</param>
        /// <returns>Returns true when the method is successful</returns>
        public bool SetProfilationOverride(string hierarchyDN, string channel, string key, PO profilation)
        {
            if (String.IsNullOrEmpty(hierarchyDN) || String.IsNullOrEmpty(channel) || String.IsNullOrEmpty(key) || profilation == null)
                return false;

            XmlSerializer xserializer = new XmlSerializer(typeof(PO));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("cp", "urn:crif-cribiscom-profile:2009-02-24");
            ns.Add("xs", "http://www.w3.org/2001/XMLSchema");
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            xserializer.Serialize(writer, profilation, ns);
            String xml = sb.ToString();

            return SetProfilationOverride(hierarchyDN, channel, key, xml);
        }

        /// <summary>
        /// Sets Profile Overrides for a user profilation
        /// </summary>
        /// <param name="hierarchyDN">The user full name to profile</param>
        /// <param name="channel">The user channel</param>
        /// <param name="key">The profile object namespace</param>
        /// <param name="profilationXml">The Profile Overrides object XML</param>
        /// <returns>Returns true when the method is successful</returns>
        private bool SetProfilationOverride(string hierarchyDN, string channel, string key, string profilationXml)
        {
            if (String.IsNullOrEmpty(hierarchyDN) || String.IsNullOrEmpty(channel) || String.IsNullOrEmpty(key) || String.IsNullOrEmpty(profilationXml))
                return false;

            ProfileKey profileKey = new ProfileKey(hierarchyDN, channel, key);
            lockRoot.AcquireWriterLock(LOCKDELAY);
            try
            {
                ProfilationDataOverride data = new ProfilationDataOverride(profileKey, profilationXml);
                DBHelper.SetProfilationOverride(connectionString, data);
            }
            finally {
                lockRoot.ReleaseWriterLock();
            }

            Console.WriteLine("Removed at {0} after SetProfilationOverride", DateTime.Now.ToLongTimeString());
            RemoveProfile(profileKey);

            return true;
        }

        /// <summary>
        /// Clears Profile Overrides for a user profilation
        /// </summary>
        /// <param name="hierarchyDN">The user full name to profile</param>
        /// <param name="channel">The user channel</param>
        /// <param name="key">The profile object namespace</param>
        /// <returns>Returns true when the method is successful</returns>
        public bool ClearProfilationOverride(string hierarchyDN, string channel, string key)
        {
            PO emptyOverride = new PO();

            return SetProfilationOverride(hierarchyDN, channel, key, emptyOverride);
        }

        /// <summary>
        /// Sets a Profile for a user profilation
        /// </summary>
        /// <param name="hierarchyDN">The user full name to profile</param>
        /// <param name="channel">The user channel</param>
        /// <param name="key">The profile object namespace</param>
        /// <param name="profile">The Profile object</param>
        /// <param name="namespaces">The Profile object serialization namespaces</param>
        /// <returns>Returns true when the method is successful</returns>
        public bool SetProfilationProfile(string hierarchyDN, string channel, string key, T profile, XmlSerializerNamespaces namespaces)
        {
            if (String.IsNullOrEmpty(hierarchyDN) || String.IsNullOrEmpty(channel) || String.IsNullOrEmpty(key) || profile == null)
                return false;

            XmlSerializer xserializer = new XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            xserializer.Serialize(writer, profile, namespaces);
            String xml = sb.ToString();

            return SetProfilationProfile(hierarchyDN, channel, key, xml);
        }

        /// <summary>
        /// Sets a Profile for a user profilation
        /// </summary>
        /// <param name="hierarchyDN">The user full name to profile</param>
        /// <param name="channel">The user channel</param>
        /// <param name="key">The profile object namespace</param>
        /// <param name="profileXml">The Profile object XML</param>
        /// <param name="namespaces">The Profile object serialization namespaces</param>
        /// <returns>Returns true when the method is successful</returns>
        private bool SetProfilationProfile(string hierarchyDN, string channel, string key, string profileXml)
        {
            if (String.IsNullOrEmpty(hierarchyDN) || String.IsNullOrEmpty(channel) || String.IsNullOrEmpty(key) || String.IsNullOrEmpty(profileXml))
                return false;

            ProfileKey profileKey = new ProfileKey(hierarchyDN, channel, key);
            lockRoot.AcquireWriterLock(LOCKDELAY);
            try
            {
                ProfilationDataProfile data = new ProfilationDataProfile(profileKey, profileXml);
                DBHelper.SetProfilationProfile(connectionString, data);
            }
            finally {
                lockRoot.ReleaseWriterLock();
            }

            Console.WriteLine("Removed at {0} after SetProfilationProfile", DateTime.Now.ToLongTimeString());
            RemoveProfile(profileKey);

            return true;
        }

        /// <summary>
        /// Update a Profile for a user profilation
        /// </summary>
        /// <param name="hierarchyDN">The user full name to profile</param>
        /// <param name="channel">The user channel</param>
        /// <param name="key">The profile object namespace</param>
        /// <param name="profile">The Profile object</param>
        /// <param name="namespaces">The Profile object serialization namespaces</param>
        /// <returns>Returns true when the method is successful</returns>
        public bool UpdateProfilationProfile(string hierarchyDN, string channel, string key, T profile, XmlSerializerNamespaces namespaces)
        {
            if (String.IsNullOrEmpty(hierarchyDN) || String.IsNullOrEmpty(channel) || String.IsNullOrEmpty(key) || profile == null)
                return false;

            XmlSerializer xserializer = new XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            xserializer.Serialize(writer, profile, namespaces);
            String xml = sb.ToString();

            return UpdateProfilationProfile(hierarchyDN, channel, key, xml);
        }

        /// <summary>
        /// Update a Profile for a user profilation
        /// </summary>
        /// <param name="hierarchyDN">The user full name to profile</param>
        /// <param name="channel">The user channel</param>
        /// <param name="key">The profile object namespace</param>
        /// <param name="profileXml">The Profile object XML</param>
        /// <param name="namespaces">The Profile object serialization namespaces</param>
        /// <returns>Returns true when the method is successful</returns>
        private bool UpdateProfilationProfile(string hierarchyDN, string channel, string key, string profileXml)
        {
            if (String.IsNullOrEmpty(hierarchyDN) || String.IsNullOrEmpty(channel) || String.IsNullOrEmpty(key) || String.IsNullOrEmpty(profileXml))
                return false;

            ProfileKey profileKey = new ProfileKey(hierarchyDN, channel, key);
            lockRoot.AcquireWriterLock(LOCKDELAY);
            try
            {
                ProfilationDataProfile data = new ProfilationDataProfile(profileKey, profileXml);
                DBHelper.UpdateProfilationProfile(connectionString, data);
            }
            finally
            {
                lockRoot.ReleaseWriterLock();
            }

            Console.WriteLine("Removed at {0} after SetProfilationProfile", DateTime.Now.ToLongTimeString());
            RemoveProfile(profileKey);

            return true;
        }

        /// <summary>
        /// Deletes Profile Overrides for a user profilation
        /// </summary>
        /// <param name="hierarchyDN">The user full name to profile</param>
        /// <param name="channel">The user channel</param>
        /// <param name="key">The profile object namespace</param>
        /// <returns>Returns true when the method is successful</returns>
        public bool DeleteProfilation(string hierarchyDN, string channel, string key)
        {
            if (String.IsNullOrEmpty(hierarchyDN) || String.IsNullOrEmpty(channel) || String.IsNullOrEmpty(key))
                return false;

            ProfileKey profileKey = new ProfileKey(hierarchyDN, channel, key);
            lockRoot.AcquireWriterLock(LOCKDELAY);
            try
            {
                DBHelper.DeleteProfilation(connectionString, profileKey);
            }
            finally
            {
                lockRoot.ReleaseWriterLock();
            }

            Console.WriteLine("Removed at {0} after DeleteProfilation", DateTime.Now.ToLongTimeString());
            RemoveProfile(profileKey);

            return true;
        }

        public bool AddActions(string hierarchyDN, string actionFOfNotify)
        {
            if (String.IsNullOrEmpty(hierarchyDN))
                return false;

            DBHelper.InsertOrDeleteActions(connectionString, actionFOfNotify, hierarchyDN, 1); // 1 = insert
            return true;
        }

        public bool DeleteActions(string hierarchyDN, string actionFOfNotify)
        {
            if (String.IsNullOrEmpty(hierarchyDN))
                return false;

            DBHelper.InsertOrDeleteActions(connectionString, actionFOfNotify, hierarchyDN, 0); // 0 = remove

            return true;
        }

        private void AddProfile(ProfileKey key) {
            ProfileData profileData = DBHelper.GetProfile(this.connectionString, key);
            if (null != profileData) {
                XmlSerializer xserializer = new XmlSerializer(typeof(T));
                T profile = null;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(profileData.Xml);
                XPathNavigator navigator = doc.CreateNavigator();
                XmlNamespaceManager nsManager = new XmlNamespaceManager(navigator.NameTable);
                XmlReader tmpReader = null;
                XPathExpression expression = null;
                XPathNavigator selected = null;
                foreach (string profileOverride in profileData.Overrides.Values) {
                    tmpReader = XmlReader.Create(new StringReader(profileOverride));
                    while (tmpReader.Read()) {
                        if (tmpReader.NodeType == XmlNodeType.Element) {
                            switch (tmpReader.LocalName) {
                                case "ND":
                                    String prefix = tmpReader.GetAttribute("P");
                                    if(prefix == null)
                                        throw new ApplicationException("Prefix missing in element ND");
                                    String uri = tmpReader.GetAttribute("N");
                                    if (uri == null)
                                        throw new ApplicationException("Namespace Uri missing in element ND");
                                    nsManager.AddNamespace(prefix, uri);
                                    break;
                                case "O":
                                    String xpath = tmpReader.GetAttribute("X");
                                    if (xpath == null)
                                        throw new ApplicationException("XPath missing in element O");
                                    expression = navigator.Compile(xpath);
                                    expression.SetContext(nsManager);
                                    selected = navigator.SelectSingleNode(expression);
                                    if (selected == null)
                                        throw new ApplicationException(String.Format(@"The XPath {0} does not match any node in the default profile", xpath));
                                    selected.SetValue(tmpReader.GetAttribute("V") ?? String.Empty);
                                    break;
                            }
                        }
                    }
                }
                using (MemoryStream output = new MemoryStream()) {
                    doc.Save(output);
                    output.Position = 0;
                    profile = xserializer.Deserialize(output) as T;
                }
                vProfiles[key] = profile;
                ProfileTimer timer = new ProfileTimer(key, profileData.Expiry);
                timer.Expired += new ExpriredProfileEventHandler(timer_Expired);
                vExpiryTimes[key] = timer;
                timer.Start();
            }
        }

        private void RemoveProfile(ProfileKey key) {
            if (vProfiles.ContainsKey(key)) {
                lockRoot.AcquireWriterLock(LOCKDELAY);
                try {
                    if (vProfiles.ContainsKey(key)) {
                        vProfiles.Remove(key);
                        if (vExpiryTimes.ContainsKey(key)) {
                            ProfileTimer tmpTimer = vExpiryTimes[key];
                            vExpiryTimes.Remove(key);
                            tmpTimer.Dispose();
                        }
                    }
                }
                finally {
                    lockRoot.ReleaseWriterLock();
                }
            }
        }

        private void timer_Expired(ProfileKey key) {
            Console.WriteLine("Rmoved at {0}", DateTime.Now.ToLongTimeString());
            RemoveProfile(key);
        }
    }
}
