using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Helpers
{
    public static class CustomExtensions
    {
        /// <summary>
        /// Extract the last 4 digits from a string (ID)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetPostalCode(this string str)
        {
            string res = "";

            for (int i = str.Length - 1, max = 0; i >= 0 && max < 4; i--)
            {
                var c = str[i];

                if (c >= '0' && c <= '9')
                {
                    res = c + res;
                    max++;
                }

            }

            return res;
        }
    }
}
