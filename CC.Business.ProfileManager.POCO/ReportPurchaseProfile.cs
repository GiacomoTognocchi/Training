using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Business.ProfileManager.POCO
{
    public class ReportPurchaseProfile
    {
        public String DefaultCompanyReport { get; set; }
        public String DefaultCompanyReportLT { get; set; }
        public String DefaultPersonReport { get; set; }
        public String DefaultPersonReportLT { get; set; }
        public String DefaultPublicAdministrationReport { get; set; }
        public String DefaultMasterCardReport { get; set; }
    }
}
