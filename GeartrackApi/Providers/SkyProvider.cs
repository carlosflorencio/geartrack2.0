using GeartrackApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeartrackApi.Providers
{
    public class SkyProvider : IProvider
    {
        public string Url { get; set; } = "http://www.sky56.cn/track/track/result?tracking_number={0}";

        public bool ValidateId(string id)
        {
            if (id.StartsWith("PQ")) return true;
            if (id.StartsWith("NL")) return true;
            if (id.StartsWith("LV")) return true;
            if (id.StartsWith("SY")) return true;

            throw new InvalidIdException();
        }



    }
}
