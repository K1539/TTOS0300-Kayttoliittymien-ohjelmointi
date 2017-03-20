using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public class API
    {
        public static string GetJsonFromLiikenneVirasto(string filter)
        {
            try
            {
                string url = "";
                url = @"http://rata.digitraffic.fi/api/v1/live-trains?station=" + filter;
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString(url);
                    return json;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
