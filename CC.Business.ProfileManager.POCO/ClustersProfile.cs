using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Business.ProfileManager.POCO
{
    public class ClustersProfile
    {
        public IEnumerable<Cluster> DefaultClusters { get; set; }
        public IEnumerable<Cluster> CustomClusters { get; set; }
    }

    public class Cluster
    {
        public Guid Code { get; set; }
        public string Name { get; set; }
    }
}
