using CC.Core.Business;
using CC.Core.Common;
using CC.Core.Common.Logging;
using CC.Core.Web.Controllers;

using CC.Business.ProfileManager.Core.CribisComX;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CC.Business.ProfileManager.POCO;
using CC.Business.ProfileManager.Core.CribisComX.ProfileOverride;
using System.Linq;
using CC.Business.ProfileManager.WebApi.CribisComX;

namespace CC.Business.ProfileManagerUpdate.WebApi.CribisComX.Controllers
{
    /// <summary>
    /// Clusters Profile
    /// </summary>
    /// <seealso cref="CC.Core.Web.Controllers.CCBaseController{VirtualDeskController, ServiceRegistry}" />
    [Route("[controller]/[action]")]
    public class VirtualDeskController : CCBaseController<VirtualDeskController, ServiceRegistry>
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
        public VirtualDeskController(IServiceRegistry serviceRegistry, ICCLogger logger,
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
        public void UpdateVirtualDeskProfile([FromBody]VirtualDeskProfile vdProfile)
        {
            var pm = ProfileStore<CP>.GetProfileManager(configurationProxy.ConfigurationObject.ProfileStoreConnectionString);
            PO po = MapOverrides(vdProfile);
            pm.SetProfilationOverride(userProfileManger.UserNameDistinguishName.ToString(), "W", configurationProxy.ConfigurationObject.VirtualDeskProfileNamespace, po);
        }

        private PO MapOverrides(VirtualDeskProfile vdProfile)
        {
            var po = new PO();

            var folder1 = vdProfile?.Folder?.ElementAtOrDefault(0)?.Code ?? string.Empty;
            var folder2 = vdProfile?.Folder?.ElementAtOrDefault(1)?.Code ?? string.Empty;
            var folder3 = vdProfile?.Folder?.ElementAtOrDefault(2)?.Code ?? string.Empty;
            var folder4 = vdProfile?.Folder?.ElementAtOrDefault(3)?.Code ?? string.Empty;

            po.AddNameSpace("vd", configurationProxy.ConfigurationObject.VirtualDeskProfileNamespace);
            po.AddOverride("vd:VDP/vd:FOLDER1/@Code", folder1);
            po.AddOverride("vd:VDP/vd:FOLDER2/@Code", folder2);
            po.AddOverride("vd:VDP/vd:FOLDER3/@Code", folder3);
            po.AddOverride("vd:VDP/vd:FOLDER4/@Code", folder4);
            return po;
        }
    }
}
