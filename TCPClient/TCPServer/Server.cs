using System.Net.Sockets;
using System.Net;
using System.Text;

internal class Server
{
    private static void Main(string[] args)
    {
        TcpListener server = new TcpListener(IPAddress.Loopback, 9999);
        server.Start(); 
        TcpClient client = server.AcceptTcpClient();  

        NetworkStream ns = client.GetStream(); //networkstream is used to send/receive messages

        while (client.Connected)  //while the client is connected, we look for incoming messages
        {
            byte[] msg = new byte[1024];     //the messages arrive as byte array
            ns.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client
            string str = Encoding.Default.GetString(msg);
            if(str.StartsWith("q"))
            {
                server.Stop();
                break;
            } else {
                Console.WriteLine($"received message: {str}"); //now , we write the message as string
            }
                
        }
    }
}