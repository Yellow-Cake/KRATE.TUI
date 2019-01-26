using System.Net;
using System.IO;

namespace StandaloneExample.RestClient {
  class Utility {
    public static string Get(string uri){
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using(Stream stream = response.GetResponseStream())
        using(StreamReader reader = new StreamReader(stream)){
            return reader.ReadToEnd();
        }
    }
  }
}
