using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TP11SysManagement
{
    internal class TP11Prog
    {
        static void Main(string[] args)
        {

            if(args.Length == 0)
            {
                String path = System.Reflection.Assembly.GetEntryAssembly().Location;
                ProcessStartInfo startInfo = new ProcessStartInfo(path);
                startInfo.Verb = "runas";
                startInfo.Arguments = "s";
                System.Diagnostics.Process.Start(startInfo);
            } else
            {
                ServiceManager sm = new ServiceManager();
                PrintArray("Services:", GetServices().Take(5).ToArray());
                PrintArray("Drives:", GetDrives().Take(5).ToArray());
                PrintArray("Processes:", GetProcesses().Take(5).ToArray());
                string[] commands = new string[]
                {
                "kill: <serviceName> -k",
                "stop: <serviceName> -S",
                "start: <serviceName> -s",
                "restart: <serviceName> -r",
                "quit: exit"
                };
                CommandHandler ch = new CommandHandler();

                var inLoop = true;
                while (inLoop)
                {
                    PrintArray("List of commands:", commands);

                    string command = Console.ReadLine();
                    Tuple<int, string> res = ch.handleCommand(command);
                    switch (res.Item1)
                    {
                        case -2: break;
                        case -1: inLoop = false; break;
                        case 0: sm.stop(res.Item2); break;
                        case 1: sm.start(res.Item2); break;
                        case 2: sm.stop(res.Item2); break;
                        case 3: sm.restart(res.Item2); break;
                    }
                }
            }
            

            
        }

        public static void PrintArray(string title, string[] values)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine(title);
            Console.WriteLine("-------------------------------");
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
        }

        public static string[] GetServices()
        {
            WqlObjectQuery wqlObjectQuery = new WqlObjectQuery(string.Format("SELECT * FROM Win32_Service"));
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(wqlObjectQuery);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            List<string> names = new List<string>();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                string dirtyName = (managementObject.Path.ToString());
                string cleanName = Regex.Matches(dirtyName, "\"(.*?)\"")[0].ToString().Replace("\"", "");
                names.Add(cleanName);
            }

            return names.ToArray();
        }
        public static string[] GetProcesses()
        {
            ObjectQuery query = new ObjectQuery("select * from Win32_Process");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection collection = searcher.Get();
            List<string> names = new List<string>();

            foreach (ManagementObject obj in collection)
            {
                if (obj["ExecutablePath"] != null)
                {
                    string processPath = obj["ExecutablePath"].ToString();
                    names.Add(processPath);
                }
            }
            return names.ToArray();
        }
        public static string[] GetDrives()
        {
            WqlObjectQuery q = new WqlObjectQuery("SELECT * FROM Win32_DiskDrive");
            List<string> names = new List<string>();

            using (ManagementObjectSearcher res = new ManagementObjectSearcher(q))
            {
                foreach (ManagementObject o in res.Get())
                {
                    // Console.WriteLine("Caption = " + o["Caption"]);
                    names.Add(o["Name"].ToString());

                    /*Console.WriteLine("Caption = " + o["Caption"]);
                    Console.WriteLine("DeviceID = " + o["DeviceID"]);
                    Console.WriteLine("Decsription = " + o["Description"]);
                    Console.WriteLine("Manufacturer = " + o["Manufacturer"]);
                    Console.WriteLine("MediaType = " + o["MediaType"]);
                    Console.WriteLine("Model = " + o["Model"]);
                    Console.WriteLine("Name = " + o["Name"]);
                    // only in Vista, 2008 & etc: //Console.WriteLine("SerialNumber = " + o["SerialNumber"]);*/
                }
            }
            return names.ToArray();
        }
    }

   

}
