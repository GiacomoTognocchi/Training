using CC.Core.Business.Configuration;

namespace CC.Business.ProfileManagerUpdate.WebApi.CribisComX
{
    public class ConfigurationObject : ConfigurationObjectBase
    {
        public string ProfileStoreConnectionString { get; set; }
        public string ClustersProfileNamespace { get; set; }
        public string VirtualDeskProfileNamespace { get; set; }
    }
}
