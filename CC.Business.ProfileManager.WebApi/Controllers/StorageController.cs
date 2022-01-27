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
    /// ITrade Controller
    /// </summary>
    /// <seealso cref="CC.Core.Web.Controllers.CCBaseController{ITradeController, ServiceRegistry}" />
    [Route("[controller]/[action]")]
    public class StorageController : CCBaseController<StorageController, ServiceRegistry>
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
        public StorageController(IServiceRegistry serviceRegistry, ICCLogger logger,
          IConfigurationRoot configuration, IConfigurationProxy<ConfigurationObject> configurationProxy,
          ICCService service, IApiProxy apiProxy, IUserProfileManager userProfileManger)
            : base(serviceRegistry, logger, configuration, service, apiProxy, userProfileManger)
        {
            this.configurationProxy = configurationProxy;
            this.userProfileManger = userProfileManger;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the i trade profile.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public POCO.StorageProfile GetStorageProfile()
        {
            var stp = ProfileStore<Core.CribisComX.BusinessObjects.STP>.GetProfileManager(configurationProxy.ConfigurationObject.ProfileStoreConnectionString);
            var storage = stp.GetProfile(userProfileManger.UserNameDistinguishName.ToString(), "W",
                configurationProxy.ConfigurationObject.StorageProfileNamespace);
            return Map(storage);
        }
        #endregion Public Methods

        #region Private Methods
        private POCO.StorageProfile Map(Core.CribisComX.BusinessObjects.STP stp)
        {
            if (stp == null)
                return null;

            var ret = new POCO.StorageProfile();
            if(stp.D != null)
            {
                ret.D = new POCO.SD
                {
                    A = stp.D.A,
                    D = stp.D.D
                };
            }

            if (stp.DL != null)
            {
                ret.DL = new POCO.SD
                {
                    A = stp.DL.A,
                    D = stp.DL.D
                };
            }

            switch (stp.T)
            {
                case Core.CribisComX.BusinessObjects.STPT.Private:
                    ret.TPT = POCO.STPT.Private;
                    break;
                case Core.CribisComX.BusinessObjects.STPT.Public:
                    ret.TPT = POCO.STPT.Public;
                    break;
                case Core.CribisComX.BusinessObjects.STPT.Both:
                    ret.TPT = POCO.STPT.Both;
                    break;
                default:
                    break;
            }

            return ret;
        }
        #endregion Private Methods
    }
}