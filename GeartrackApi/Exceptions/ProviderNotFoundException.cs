using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Exceptions
{
    public class ProviderNotFoundException : Exception
    {
        public ProviderNotFoundException() { }

        public ProviderNotFoundException(string message) : base(message) { }

        public ProviderNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
