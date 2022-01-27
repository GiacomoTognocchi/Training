using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Business.ProfileManager.POCO
{
    public class VirtualDeskProfile
    {
        public List<VirtualDeskFolder> Folder { get; set; }
    }

    public class VirtualDeskFolder
    {
        public string Code { get; set; }
        public int Order { get; set; }
    }
}
