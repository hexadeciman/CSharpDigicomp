using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.IO;

namespace WCFWeather.Service
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://gist.githubusercontent.com/VerizonMediaOwner/9f088743f397d94ba2fe7c6f8c8f5a05/raw/5ab3a9ef755fa2a9fce8246df1d5828bd1604d76/weather_ydn_rss.xml";
            Weather data = await FetchData<Weather>(url);
            Console.WriteLine(data.Channel.Description);
            Console.ReadKey();
        }

        public static async Task<T> FetchData<T>(string url)
        {
            return await Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                {
                    string xmlData = client.DownloadString(url);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    T rss = (T)serializer.Deserialize(new StringReader(xmlData));
                    return rss;
                }
            });   
        }
    }
}
