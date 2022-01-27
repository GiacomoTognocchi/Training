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

namespace CC.Business.ProfileManager.WebApi.CribisComX.Controllers
{
    /// <summary>
    /// Report Purchase Profile
    /// </summary>
    /// <seealso cref="CC.Core.Web.Controllers.CCBaseController{ProductsPurchaseController, ServiceRegistry}" />
    [Route("[controller]/[action]")]
    public class ProductsPurchaseController : CCBaseController<ProductsPurchaseController, ServiceRegistry>
    {
        private IConfigurationProxy<ConfigurationObject> configurationProxy;
        private IUserProfileManager userProfileManger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanySearchController"/> class.
        /// </summary>
        /// <param name="serviceRegistry">The service registry.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="service">The service.</param>
        /// <param name="apiProxy">The API proxy.</param>
        public ProductsPurchaseController(IServiceRegistry serviceRegistry, ICCLogger logger,
          IConfigurationRoot configuration, IConfigurationProxy<ConfigurationObject> configurationProxy,
          ICCService service, IApiProxy apiProxy, IUserProfileManager userProfileManger)
            : base(serviceRegistry, logger, configuration, service, apiProxy, userProfileManger)
        {
            this.configurationProxy = configurationProxy;
            this.userProfileManger = userProfileManger;
        }

        /// <summary>
        /// Gets the Virtual Desk Profile
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ProductsPilotPurchaseProfile GetProductPilotPurchaseProfile()
        {            
            var pm = ProfileStore<PLP>.GetProfileManager(configurationProxy.ConfigurationObject.ProfileStoreConnectionString);
            var profile = pm.GetProfile(userProfileManger.UserNameDistinguishName.ToString(), "W", configurationProxy.ConfigurationObject.ProductsPurchaseProfileNamespace);
            return MapResult(profile);           
            
        }

        private ProductsPilotPurchaseProfile MapResult(PLP profile)
        {
            return new ProductsPilotPurchaseProfile
            { 
               CompanyProducts = new List<string> { profile.C?.PC1, profile.C?.PC2, profile.C?.PC3 }
            };
        }
    }
}
