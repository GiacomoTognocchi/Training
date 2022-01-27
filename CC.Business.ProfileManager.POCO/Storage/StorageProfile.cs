using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Business.ProfileManager.POCO
{
    public class StorageProfile
    {
        public SD D { get; set; }

        public SD DL { get; set; }

        public STPT TPT { get; set; }
    }

    public class SD
    {
        public bool A { get; set; }
        public string D { get; set; }
    }

    public enum STPT
    {
        Private,
        Public,
        Both
    }
}
