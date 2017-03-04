using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Exceptions
{
    public class ProviderException : Exception
    {
        public ProviderException() { }

        public ProviderException(string message) : base(message) { }

        public ProviderException(string message, Exception inner) : base(message, inner) { }
    }
}
