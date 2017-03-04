using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Models
{
    public class ErrorResponse
    {
        public ErrorResponse(string err)
        {
            error = err;
        }

        public string error { get; set; }
    }
}
