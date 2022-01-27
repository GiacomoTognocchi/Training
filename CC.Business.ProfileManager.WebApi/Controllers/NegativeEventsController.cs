// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

//using CC.Business.ProfileManager.Core.CribisComX;
using CC.Business.ProfileManager.Core.CribisComX;
using CC.Business.ProfileManager.POCO.NegativeEvents;
using CC.Core.Business;
using CC.Core.Common;
using CC.Core.Common.Logging;
using CC.Core.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Controllers
{
    /// <summary>
    /// Company Report Controller
    /// </summary>
    /// <seealso cref="CC.Core.Web.Controllers.CCBaseController{AntiFraudController, ServiceRegistry}" />
    [Route("[controller]/[action]")]
    public class NegativeEventsController : CCBaseController<NegativeEventsController, ServiceRegistry>
    {
        #region Private Fields

        /// <summary>
        /// The configuration proxy
        /// </summary>
        private readonly IConfigurationProxy<ConfigurationObject> configurationProxy;

        /// <summary>
        /// The user profile manger
        /// </summary>
        private readonly IUserProfileManager userProfileManger;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AntiFraudController" /> class.
        /// </summary>
        /// <param name="serviceRegistry">The service registry.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="configurationProxy">The configuration proxy.</param>
        /// <param name="service">The service.</param>
        /// <param name="apiProxy">The API proxy.</param>
        /// <param name="userProfileManger">The user profile manger.</param>
        public NegativeEventsController(IServiceRegistry serviceRegistry, ICCLogger logger,
          IConfigurationRoot configuration, IConfigurationProxy<ConfigurationObject> configurationProxy,
          ICCService service, IApiProxy apiProxy, IUserProfileManager userProfileManger)
            : base(serviceRegistry, logger, configuration, service, apiProxy, userProfileManger)
        {
            this.configurationProxy = configurationProxy;
            this.userProfileManger = userProfileManger;
        }

        #endregion Public Constructors

        #region Public Methods

        //TODO metodi per accounting price
       
        /// <summary>
        /// Gets the anti fraud profile.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public NegativeEventProfile GetNegativeEventsProfile()
        {
            var pm = ProfileStore<CC.Business.ProfileManager.Core.CribisComX.NEP>.GetProfileManager(configurationProxy.ConfigurationObject.ProfileStoreConnectionString);
            var profile = pm.GetProfile(userProfileManger.UserNameDistinguishName.ToString(), "W",
                configurationProxy.ConfigurationObject.NegativeEventsProfileNamespace);
            return Mapper.NegativeEventsProfile.Map(profile);
        }
        
        #endregion Public Methods
    }
}