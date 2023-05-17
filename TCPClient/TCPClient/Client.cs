using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Client
{
    public static byte[] strToBytes(string msg)
    {
        return ASCIIEncoding.ASCII.GetBytes(msg);
    }
    private static void Main(string[] args)
    {
        TcpClient client = new TcpClient(new IPEndPoint(IPAddress.Loopback, 0));
        client.Connect(new IPEndPoint(IPAddress.Loopback, 9999));
        NetworkStream nwStream = client.GetStream();

        Boolean finished = false;
        //send data to server

        while(!finished)
        {
            Console.WriteLine("Write message to send");
            string msg = Console.ReadLine();

            if(String.IsNullOrEmpty(msg))
            {
                continue;
            }

            byte[] msgBytes = strToBytes(msg);

            if (msg == "q")
            {
                nwStream.Write(msgBytes, 0, msgBytes.Length);
                client.Close();
                finished = true;
                continue;
            }
            else
            {
                nwStream.Write(msgBytes, 0, msgBytes.Length);
            }
            

        }

    }
}