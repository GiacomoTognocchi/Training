namespace CC.Business.ProfileManager.Core.CribisComX 
{
    public abstract class ProfilationDataKey 
    {
        private ProfileKey key;

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

        protected ProfilationDataKey(ProfileKey key)
        {
            this.key = key;
        }
    }
}
