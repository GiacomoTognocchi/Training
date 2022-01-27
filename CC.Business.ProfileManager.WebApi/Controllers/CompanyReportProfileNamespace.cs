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
    /// <seealso cref="CC.Core.Web.Controllers.CCBaseController{CompanyReportProfileController, ServiceRegistry}" />
    [Route("[controller]/[action]")]
    public class CompanyReportProfileController : CCBaseController<CompanyReportProfileController, ServiceRegistry>
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
        public CompanyReportProfileController(IServiceRegistry serviceRegistry, ICCLogger logger,
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
        public CompanyReportProfile GetCompanyReportProfile()
        {            
            var pm = ProfileStore<CCRP>.GetProfileManager(configurationProxy.ConfigurationObject.ProfileStoreConnectionString);
            var profile = pm.GetProfile(userProfileManger.UserNameDistinguishName.ToString(), "W", configurationProxy.ConfigurationObject.CompanyReportProfileNamespace);
            return MapResult(profile);           
            
        }

        private CompanyReportProfile MapResult(CCRP profile)
        {
            return new CompanyReportProfile
            {
                SLOT1 = new POCO.ReportDefinition { PC = profile.SLOT1?.PC },
                SLOT2 = new POCO.ReportDefinition { PC = profile.SLOT2?.PC },
                SLOT3 = new POCO.ReportDefinition { PC = profile.SLOT3?.PC },
                SLOT4 = new POCO.ReportDefinition { PC = profile.SLOT4?.PC },
                SLOT5 = new POCO.ReportDefinition { PC = profile.SLOT5?.PC },
                SLOT6 = new POCO.ReportDefinition { PC = profile.SLOT6?.PC },
                SLOT7 = new POCO.ReportDefinition { PC = profile.SLOT7?.PC },
                SLOT8 = new POCO.ReportDefinition { PC = profile.SLOT8?.PC },
                SLOT9 = new POCO.ReportDefinition { PC = profile.SLOT9?.PC },
                SLOT10 = new POCO.ReportDefinition { PC = profile.SLOT10?.PC },
                SLOT11 = new POCO.ReportDefinition { PC = profile.SLOT11?.PC },
                SLOT12 = new POCO.ReportDefinition { PC = profile.SLOT12?.PC },
                SLOT13 = new POCO.ReportDefinition { PC = profile.SLOT13?.PC },
                SLOT14 = new POCO.ReportDefinition { PC = profile.SLOT14?.PC },
                SLOT15 = new POCO.ReportDefinition { PC = profile.SLOT15?.PC },
                SLOT16 = new POCO.ReportDefinition { PC = profile.SLOT16?.PC },
                SLOT17 = new POCO.ReportDefinition { PC = profile.SLOT17?.PC },
                SLOT18 = new POCO.ReportDefinition { PC = profile.SLOT18?.PC },
                SLOT19 = new POCO.ReportDefinition { PC = profile.SLOT19?.PC },
                SLOT20 = new POCO.ReportDefinition { PC = profile.SLOT20?.PC },
                SLOT21 = new POCO.ReportDefinition { PC = profile.SLOT21?.PC },
                SLOT22 = new POCO.ReportDefinition { PC = profile.SLOT22?.PC },
                SLOT23 = new POCO.ReportDefinition { PC = profile.SLOT23?.PC },
                SLOT24 = new POCO.ReportDefinition { PC = profile.SLOT24?.PC },
                SLOT25 = new POCO.ReportDefinition { PC = profile.SLOT25?.PC }

            };
        }
    }
}
