using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFHost
{
    public class TimeHelper
    {
        public static long GetTime()
        {
           DateTime currentTime = DateTime.UtcNow;
           return ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
        }
    }
}
