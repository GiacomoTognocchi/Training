using CC.Core.Business;
using CC.Core.Common;
using CC.Core.Common.Logging;
using CC.Core.Web.Controllers;

using CC.Business.ProfileManager.Core.CribisComX;
using CC.Business.ProfileManager.Core.CribisComX.BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using CC.Business.ProfileManager.POCO;
using Newtonsoft.Json;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Controllers
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
        /// Gets Clusters Profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ClustersProfile GetClustersProfile()
        {

            var pm = ProfileStore<CP>.GetProfileManager(configurationProxy.ConfigurationObject.ProfileStoreConnectionString);
            var profile = pm.GetProfile(userProfileManger.UserNameDistinguishName.ToString(), "W", configurationProxy.ConfigurationObject.ClustersProfileNamespace);

            return MapResult(profile);
        }

        private ClustersProfile MapResult(CP profile)
        {
            var jsonDefaultClusters = profile.DefaultClusters.V;
            var jsonCustomClusters = profile.CustomClusters.V;

            var defClusters = JsonConvert.DeserializeObject<List<Cluster>>(jsonDefaultClusters);
            var cusClusters = JsonConvert.DeserializeObject<List<Cluster>>(jsonCustomClusters);

            if (cusClusters == null)
                cusClusters = new List<Cluster>();

            return new ClustersProfile
            {
                DefaultClusters = defClusters,
                CustomClusters = cusClusters
            };
        }
    }
}
