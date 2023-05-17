using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using WCFHost;
namespace WCFHost
{
    public class DataService : IDataService
    {
        public static EventLog systemEventLog;

        public async Task<string> GetDataAsync()
        {
            Random rand = new Random();
            int id = rand.Next(200, 1000);
            

            systemEventLog = new EventLog("Application");
            systemEventLog.Source = "WeatherServiceLogger";
            systemEventLog.WriteEntry($"fetching weather id: {id} at {TimeHelper.GetTime()}", EventLogEntryType.Information);

            string url = "https://gist.githubusercontent.com/VerizonMediaOwner/9f088743f397d94ba2fe7c6f8c8f5a05/raw/5ab3a9ef755fa2a9fce8246df1d5828bd1604d76/weather_ydn_rss.xml";
            Weather data = await DataHelper.FetchData<Weather>(url);
            
            Thread.Sleep(id);
            systemEventLog.WriteEntry($"done fetching and serializing for id: {id} at {TimeHelper.GetTime()}", EventLogEntryType.Information);
            return JsonConvert.SerializeObject(data);
        }
    }
}
