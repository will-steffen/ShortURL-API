using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.Test
{
    public class TestUtils
    {
        public static StringContent RequestBody(object content)
        {
            StringContent ctnt = new StringContent(
                    JsonConvert.SerializeObject(content),
                    Encoding.UTF8, "application/json");
            return ctnt;
        }

        public static async Task<SerializeType> ReadResponse<SerializeType>(HttpResponseMessage response)
        {
            string txt = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SerializeType>(txt);
        }
    }
}
