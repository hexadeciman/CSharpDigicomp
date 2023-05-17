using Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using Client.ServiceReference1;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Create an instance of the WCF proxy.
            BookServiceClient client = new BookServiceClient();
            string res = client.GetBooks();
            Console.WriteLine(res);
            // Step 3: Close the client to gracefully close the connection and clean up resources.
            Console.WriteLine("\nPress <Enter> to terminate the client.");
            Console.ReadLine();
            // client.Close();
        }
    }
}
