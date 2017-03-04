using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Services
{
    public interface IHttpService
    {
        Task<String> GetAsync(string uri);
    }
}
