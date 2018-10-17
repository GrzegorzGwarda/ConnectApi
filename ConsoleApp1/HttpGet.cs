using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class HttpGet
    {
        private string BaseHttpAdress = "https://jsonplaceholder.typicode.com/";

        public async Task DeserializeObjectJson()
        {
            //json2csharp
            var getData = JsonConvert.DeserializeObject<RootObject>(await TestGet());
        }

        public async Task<string> TestGet()
        {
            string responsdata = "";
            try
            {
                var request = HttpWebRequest.CreateHttp(BaseHttpAdress + "todos/2");
                request.Method = WebRequestMethods.Http.Get;

                request.ContentType = "application/json; charset-utf-8";

                await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null)
                    .ContinueWith(x =>
                    {
                        var response = (HttpWebResponse)x.Result;

                        if(response.StatusCode == HttpStatusCode.OK)
                        {
                            StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            string responseDate = streamReader.ReadToEnd();

                            responsdata = responseDate;
                            streamReader.Close();
                        }

                        response.Close();
                    });

            }
            catch(Exception)
            {

            }

            return responsdata;


        }
    }
}
