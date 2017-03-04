using GeartrackApi.Exceptions;
using GeartrackApi.Providers;
using GeartrackApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi
{
    public class GeartrackProviders
    {
        private Dictionary<string, Lazy<IProvider>> _map;

        public GeartrackProviders(IHttpService httpService)
        {
            // Scrappers
            _map = new Dictionary<string, Lazy<IProvider>>
            {
                { "sky", new Lazy<IProvider>(() => new SkyProvider(httpService)) }
            };
        }

        public IProvider Get(string provider)
        {
            Lazy<IProvider> result;
            if (_map.TryGetValue(provider, out result))
            {
                return result.Value;
            }
            else
            {
                throw new ProviderNotFoundException();
            }
        }
    }
}
