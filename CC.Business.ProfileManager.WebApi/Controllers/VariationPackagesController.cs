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
using System.Collections.Generic;

namespace CC.Business.ProfileManager.WebApi.CribisComX.Controllers
{
    /// <summary>
    /// Market Lab Controller
    /// </summary>
    /// <seealso cref="CC.Core.Web.Controllers.CCBaseController{NotificationsController, ServiceRegistry}" />
    [Route("[controller]/[action]")]
    public class VariationPackagesController : CCBaseController<NotificationsController, ServiceRegistry>
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
        public VariationPackagesController(IServiceRegistry serviceRegistry, ICCLogger logger,
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
        /// Gets the notifications profile.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<string> GetVariationPackages()
        {
			var connectionString = configurationProxy.ConfigurationObject.VariationPackagesConnectionString;
			var userDistinguishName = UserDistinguishName.ParseString(userProfileManger.UserNameDistinguishName.ToString());
			var userFullName = userDistinguishName.GetSubscriberDistinguishName().ToString();
			return DBHelper.GetVariationPackages(connectionString, userFullName);
        }
		/// <summary>
		/// Gets the notifications profile for PA.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public List<string> GetVariationPackagesPA()
		{
			var connectionString = configurationProxy.ConfigurationObject.VariationPackagesConnectionString;
			return DBHelper.GetVariationPackagesPA(connectionString);
		}
		#endregion Public Methods
	}
}
