using Java.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EasyTourYuriHugo.Services
{

    public class RestClient<T>
    {
        HttpClient client;
        private String url;

        public RestClient(String url)
        {
            this.url = url.Trim();
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<T>> buscarCategoriasRoteiro()
        {
            var response = await client.GetStringAsync(this.url);

            return JsonConvert.DeserializeObject<List<T>>(response);
         
        }
    }
}
