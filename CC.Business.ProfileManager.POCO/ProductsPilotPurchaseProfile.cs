using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Business.ProfileManager.POCO
{
    public class ProductsPilotPurchaseProfile
    {

        public List<string> CompanyProducts { get; set; }
        public List<string> CompanyLTProducts { get; set; }
        public List<string> PersonProducts { get; set; }
        public List<string> PersonLTProducts { get; set; }

    }

   
}
