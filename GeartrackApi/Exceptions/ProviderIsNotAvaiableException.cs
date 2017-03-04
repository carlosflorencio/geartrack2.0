using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Exceptions
{
    public class ProviderIsNotAvaiableException : ProviderException
    {
        public ProviderIsNotAvaiableException() { }

        public ProviderIsNotAvaiableException(string message) : base(message) { }

        public ProviderIsNotAvaiableException(string message, Exception inner) : base(message, inner) { }
    }
}
