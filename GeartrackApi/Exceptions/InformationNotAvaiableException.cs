using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Exceptions
{
    public class InformationNotAvaiableException : Exception
    {
        public InformationNotAvaiableException() { }

        public InformationNotAvaiableException(string message) : base(message) { }

        public InformationNotAvaiableException(string message, Exception inner) : base(message, inner) { }
    }
}
