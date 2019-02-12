using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KrateTUI.RestClient {
    class Utility {

        private static readonly HttpClient client = new HttpClient();

        public static JObject Get(string uri){
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using(Stream stream = response.GetResponseStream())
            using(StreamReader reader = new StreamReader(stream)){
                    return JObject.Parse(reader.ReadToEnd());
            }
        }

        public static string Post(string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:37220/swagger/index.html");

            var postData = "thing1=hello";
            postData += "&amp;amp;amp;amp;amp;thing2=world";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
    }
}
