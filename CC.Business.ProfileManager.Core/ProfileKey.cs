
using System;
namespace CC.Business.ProfileManager.Core.CribisComX {
    /// <summary>
    /// 
    /// </summary>
    public struct ProfileKey {
        public string HierarchyDN;
        public string Gateway;
        public string Namespace;

        public ProfileKey(string hierarchyDN, string channel, string ns) {
            this.HierarchyDN = hierarchyDN;
            this.Gateway = channel;
            this.Namespace = ns;
        }
        
        public override string ToString() {
            return string.Format("{0}_{1}_{2}", HierarchyDN, Gateway, Namespace);
        }
    }
}
