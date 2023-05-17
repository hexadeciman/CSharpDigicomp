using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WCFHost
{
    public static class DataHelper
    {
        public static async Task<T> FetchData<T>(string url)
        {
            return await Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                {
                    string xmlData = client.DownloadString(url);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    T serializedObject = (T)serializer.Deserialize(new StringReader(xmlData));
                    return serializedObject;
                }
            });
        }
    }
}
