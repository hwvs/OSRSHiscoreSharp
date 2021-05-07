using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OSRSHiscoreSharp
{
    internal class Web
    {
        public async static Task<string> GETRequest(string uri)
        {
            return await GETRequest(new Uri(uri));
        }
        public async static Task<string> GETRequest(Uri uri)
        {
            // TODO: Replace this with a proper http request
            using (var wc = new WebClient())
            {
                return await wc.DownloadStringTaskAsync(uri);
            }
        }

    }
}
