using System;
using System.Collections.Generic;

namespace CC.Business.ProfileManager.Core.CribisComX {
    public class ProfileData {
        private ProfileKey key;
        public Dictionary<string, string> Overrides;
        public string Xml;
        public ExpiryData Expiry;

        public string Namespace {
            get {
                return key.Namespace;
            }
        }

        public string Channel {
            get {
                return key.Gateway;
            }
        }

        public string HierarchyDN {
            get {
                return key.HierarchyDN;
            }
        }

        public ProfileData(ProfileKey key) {
            this.key = key;
            this.Overrides = new Dictionary<string, string>();
            this.Xml = "";
            this.Expiry = new ExpiryData(TimeSpan.Zero, false);
        }
    }
}
