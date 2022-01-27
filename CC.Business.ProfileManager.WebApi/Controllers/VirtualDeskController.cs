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
    /// Virtual Desk Profile
    /// </summary>
    /// <seealso cref="CC.Core.Web.Controllers.CCBaseController{VirtualDeskController, ServiceRegistry}" />
    [Route("[controller]/[action]")]
    public class VirtualDeskController : CCBaseController<VirtualDeskController, ServiceRegistry>
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
        public VirtualDeskController(IServiceRegistry serviceRegistry, ICCLogger logger,
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
        public VirtualDeskProfile GetVirtualDeskProfile()
        {
            var pm = ProfileStore<VDP>.GetProfileManager(configurationProxy.ConfigurationObject.ProfileStoreConnectionString);
            var profile = pm.GetProfile(userProfileManger.UserNameDistinguishName.ToString(), "W", configurationProxy.ConfigurationObject.VirtualDeskProfileNamespace);

            var res = new VirtualDeskProfile();
            res.Folder = new List<VirtualDeskFolder>();

            if (!string.IsNullOrWhiteSpace(profile.FOLDER1.Code))
                res.Folder.Add(new VirtualDeskFolder { Order = 1, Code = profile.FOLDER1.Code });

            if (!string.IsNullOrWhiteSpace(profile.FOLDER2.Code))
                res.Folder.Add(new VirtualDeskFolder { Order = 2, Code = profile.FOLDER2.Code });

            if (!string.IsNullOrWhiteSpace(profile.FOLDER3.Code))
                res.Folder.Add(new VirtualDeskFolder { Order = 3, Code = profile.FOLDER3.Code });

            if (!string.IsNullOrWhiteSpace(profile.FOLDER4.Code))
                res.Folder.Add(new VirtualDeskFolder { Order = 4, Code = profile.FOLDER4.Code });

            return res;
        }
    }
}
