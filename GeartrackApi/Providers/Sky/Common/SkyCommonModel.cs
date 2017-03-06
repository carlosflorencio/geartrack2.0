using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Providers.Sky.Common
{
    public class SkyCommonModel
    {
        public object messages { get; set; }
        public List<Status> status { get; set; }
        public int retries { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public string area { get; set; }
        public string status { get; set; }
        public string date { get; set; }
    }
}
