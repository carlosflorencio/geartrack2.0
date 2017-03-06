using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Providers.Sky.PriorityLine
{
    public class SkyPriorityLineDTO
    {
        public List List { get; set; }
        public string message { get; set; }
    }

    public class Detail
    {
        public DateTime ondate { get; set; }
        public string status { get; set; }
    }

    public class Z0
    {
        public List<Detail> Detail { get; set; }
    }

    public class Track
    {
        public string track { get; set; }
        public Z0 z0 { get; set; }
    }

    public class List
    {
        public Track Track { get; set; }
    }

}
