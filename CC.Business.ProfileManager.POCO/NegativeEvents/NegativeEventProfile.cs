using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Business.ProfileManager.POCO.NegativeEvents
{
    public class NegativeEventProfile
    {
        public Direct DirectEvents { get; set; }
        public Indirect IndirectEvents { get; set; }
    }

    public class Direct
    {
        public List<string> Roles { get; set; }
        public int EquityPercentage { get; set; }
    }

    public class Indirect
    {
        public List<string> Roles { get; set; }
    }
}
