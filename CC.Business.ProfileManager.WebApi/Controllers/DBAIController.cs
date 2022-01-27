// *****************************************************
// * Copyright (c) Crif SpA - All Right Reserved *
// *****************************************************

//using CC.Business.ProfileManager.Core.CribisComX;

using CC.Business.ProfileManager.Core.CribisComX;
using CC.Core.Business;
using CC.Core.Common;
using CC.Core.Common.Logging;
using CC.Core.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Controllers
{
    /// <summary>
    /// DBAI Controller
    /// </summary>
    /// <seealso cref="CC.Core.Web.Controllers.CCBaseController{DBAIController, ServiceRegistry}" />
    [Route("[controller]/[action]")]
    public class DBAIController : CCBaseController<DBAIController, ServiceRegistry>
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
        /// Initializes a new instance of the <see cref="CompanyReportController" /> class.
        /// </summary>
        /// <param name="serviceRegistry">The service registry.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="configurationProxy">The configuration proxy.</param>
        /// <param name="service">The service.</param>
        /// <param name="apiProxy">The API proxy.</param>
        /// <param name="userProfileManger">The user profile manger.</param>
        public DBAIController(IServiceRegistry serviceRegistry, ICCLogger logger,
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
        /// Get DBAI the profile for the current user (based on request token) or for the input userNameDistinguishName and channel.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public POCO.DBAIElegibilityProfile GetDBAIElegibilityProfile(string userNameDistinguishName = null, string channel = "W")
        {
            var pm = ProfileStore<Core.CribisComX.BusinessObjects.DBAIP>.GetProfileManager(configurationProxy.ConfigurationObject.ProfileStoreConnectionString);
            var profile = pm.GetProfile(userNameDistinguishName == null ? userProfileManger.UserNameDistinguishName.ToString(): userNameDistinguishName, channel,
                configurationProxy.ConfigurationObject.DBAIProfileNamespace);
            return Mapper.DBAIElegibilityProfile.Map(profile);
        }
        #endregion Public Methods
    }
}