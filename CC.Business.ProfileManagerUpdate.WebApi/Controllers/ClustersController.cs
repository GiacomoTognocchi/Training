using CC.Core.Business;
using CC.Core.Common;
using CC.Core.Common.Logging;
using CC.Core.Web.Controllers;

using CC.Business.ProfileManager.Core.CribisComX;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using CC.Business.ProfileManager.POCO;
using CC.Business.ProfileManager.Core.CribisComX.ProfileOverride;
using Newtonsoft.Json;
using CC.Business.ProfileManager.WebApi.CribisComX;

namespace CC.Business.ProfileManagerUpdate.WebApi.CribisComX.Controllers
{
    /// <summary>
    /// Clusters Profile
    /// </summary>
    /// <seealso cref="CC.Core.Web.Controllers.CCBaseController{ClustersController, ServiceRegistry}" />
    [Route("[controller]/[action]")]
    public class ClustersController : CCBaseController<ClustersController, ServiceRegistry>
    {
        private IConfigurationProxy<ConfigurationObject> configurationProxy;
        private IUserProfileManager userProfileManger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanySearchController" /> class.
        /// </summary>
        /// <param name="serviceRegistry">The service registry.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="configurationProxy">The configuration proxy.</param>
        /// <param name="service">The service.</param>
        /// <param name="apiProxy">The API proxy.</param>
        public ClustersController(IServiceRegistry serviceRegistry, ICCLogger logger,
          IConfigurationRoot configuration, IConfigurationProxy<ConfigurationObject> configurationProxy,
          ICCService service, IApiProxy apiProxy, IUserProfileManager userProfileManger)
            : base(serviceRegistry, logger, configuration, service, apiProxy, userProfileManger)
        {
            this.configurationProxy = configurationProxy;
            this.userProfileManger = userProfileManger;
        }


        /// <summary>
        /// Updates the clusters profile.
        /// </summary>
        /// <param name="customClusters">L'intera lista di custom cluster da sostituire.</param>
        [HttpPost]
        public void UpdateClustersProfile([FromBody]List<Cluster> customClusters)
        {
            var pm = ProfileStore<CP>.GetProfileManager(configurationProxy.ConfigurationObject.ProfileStoreConnectionString);
            PO po = MapOverrides(customClusters);
            pm.SetProfilationOverride(userProfileManger.SubscriberDistinguishName.ToString(), "W", configurationProxy.ConfigurationObject.ClustersProfileNamespace, po);
        }

        private PO MapOverrides(List<Cluster> customClusters)
        {
            var po = new PO();
            po.AddNameSpace("cc", configurationProxy.ConfigurationObject.ClustersProfileNamespace);
            var serializedClusters = JsonConvert.SerializeObject(customClusters);
            po.AddOverride("cc:CP/cc:CustomClusters/@V", serializedClusters);
            return po;
        }
    }
}
