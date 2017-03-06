using GeartrackApi.Exceptions;
using GeartrackApi.Providers.Sky.Common;
using GeartrackApi.Providers.Sky.PriorityLine;
using GeartrackApi.Services;
using Newtonsoft.Json;
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

        /*
        |--------------------------------------------------------------------------
        | Validate
        |--------------------------------------------------------------------------
        */
        public bool ValidateId(string id)
        {
            if (id.StartsWith("PQ")) return true;
            if (id.StartsWith("NL")) return true;
            if (id.StartsWith("LV")) return true;
            if (id.StartsWith("SY")) return true;

            throw new InvalidIdException();
        }

        /*
        |--------------------------------------------------------------------------
        | Parse
        |--------------------------------------------------------------------------
        */
        public async Task<object> GetInformationAndParse(string id)
        {
            var content = await _http.GetAsync(string.Format(url, id));

            switch (id[0])
            {
                case 'N': // Netherlands Post surface mail
                case 'L': // Bpost is the same
                case 'S': // Malasya Pos
                    var dto2 = JsonConvert.DeserializeObject<SkyCommonPosDTO>(content);

                    return null;
                default: // Priority Line
                    var dto = JsonConvert.DeserializeObject<SkyPriorityLineDTO>(content);
                    return new SkyPriorityLineModel(dto);
            }
        }
    }

}
