using GeartrackApi.Exceptions;
using GeartrackApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi
{
    public class GeartrackProviders
    {
        private Dictionary<string, IProvider> _map;

        public GeartrackProviders()
        {
            // Scrappers
            _map = new Dictionary<string, IProvider>
            {
                { "sky", new SkyProvider() }
            };
        }

        public IProvider Get(string provider)
        {
            IProvider result;
            if (_map.TryGetValue(provider, out result))
            {
                return result;
            }
            else
            {
                throw new ProviderNotFoundException();
            }
        }
    }
}
