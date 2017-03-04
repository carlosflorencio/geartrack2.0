using GeartrackApi.Exceptions;
using GeartrackApi.Services;
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
        private string url = "http://www.sky56.cn/track/track/result?tracking_number={0}";
        private IHttpService _http;

        public SkyProvider(IHttpService http)
        {
            _http = http;
            Console.WriteLine(http.ToString());
        }

        public bool ValidateId(string id)
        {
            if (id.StartsWith("PQ")) return true;
            if (id.StartsWith("NL")) return true;
            if (id.StartsWith("LV")) return true;
            if (id.StartsWith("SY")) return true;

            throw new InvalidIdException();
        }

        public async Task<object> GetInformationAndParse(string id)
        {
            var content = await _http.GetAsync(string.Format(url, id));

            if(content.Contains("No result found for your query."))
            {
                throw new InformationNotAvaiableException();
            }

            return content;
        }


    }
}
