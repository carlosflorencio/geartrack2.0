using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Exceptions
{
    public class FailedToParseProviderException : ProviderException
    {
        public FailedToParseProviderException() { }

        public FailedToParseProviderException(string message) : base(message) { }

        public FailedToParseProviderException(string message, Exception inner) : base(message, inner) { }
    }
}
