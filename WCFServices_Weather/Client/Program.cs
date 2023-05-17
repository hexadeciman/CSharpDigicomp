using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if(String.IsNullOrEmpty(UserSettings.Default.ServerAddress))
            {
                Console.WriteLine("Enter server address");
                UserSettings.Default.ServerAddress = Console.ReadLine();
                UserSettings.Default.Save();
            }
            if(!String.IsNullOrEmpty(UserSettings.Default.ServerAddress))
            {
                Console.WriteLine($"calling {UserSettings.Default.ServerAddress}");
                // create bindings & endpoints
                var binding = new System.ServiceModel.WSHttpBinding();
                var endpoint = new EndpointAddress(UserSettings.Default.ServerAddress);
                // var endpoint = new EndpointAddress("http://localhost:1395/WCFHost/DataService/");
                var factory = new ChannelFactory<WCFHost.IDataService>(binding, endpoint);
                var channel = factory.CreateChannel();

                try
                {
                    Parallel.Invoke(
                        async delegate () {
                            var res = await channel.GetDataAsync();
                            Console.WriteLine(res);
                        },
                        async delegate () {
                            var res = await channel.GetDataAsync();
                            Console.WriteLine(res);
                        },
                        async delegate () {
                            var res = await channel.GetDataAsync();
                            Console.WriteLine(res);
                        },
                        async delegate () {
                            var res = await channel.GetDataAsync();
                            Console.WriteLine(res);
                        }
                    );
                }

                // No exception is expected in this example, but if one is still thrown from a task,
                // it will be wrapped in AggregateException and propagated to the main thread.
                catch (AggregateException e)
                {
                    Console.WriteLine("An action has thrown an exception. THIS WAS UNEXPECTED.\n{0}", e.InnerException.ToString());
                }
                
                        
                
            }
            Console.ReadLine();
        }
    }
}
