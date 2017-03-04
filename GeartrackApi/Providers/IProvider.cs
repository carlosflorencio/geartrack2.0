using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Providers
{
    public interface IProvider
    {
        /// <summary>
        ///  Validates the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if valid, throws InvalidIdException if not</returns>
        bool ValidateId(string id);

        /// <summary>
        /// Scraps the provider website and parses the information
        /// Throws Exception if something odd occurs
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A view model</returns>
        Task<object> GetInformationAndParse(string id);
    }
}
