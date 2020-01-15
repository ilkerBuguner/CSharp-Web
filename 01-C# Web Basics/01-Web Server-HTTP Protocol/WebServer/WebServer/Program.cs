using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string NewLine = "\r\n";
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                using NetworkStream networkStream = tcpClient.GetStream();
                byte[] requestedBytes = new byte[1000000];
                int bytesRead = networkStream.Read(requestedBytes, 0, requestedBytes.Length);
                string request = Encoding.UTF8.GetString(requestedBytes, 0, bytesRead);

                string responseText = @"<form action='/Account/Login' method='post'>
<input type=date name='date' />
<input type=text name='username' />
<input type=password name='pasword' />
<input type=submit value='Login' />
</form>";

                string response = "HTTP/1.0 200 OK" + NewLine +
                                  "Server: SoftuniServer/1.0" + NewLine +
                                  "Content-Type: text/html" + NewLine +
                                  NewLine +
                                  responseText;
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                networkStream.Write(responseBytes, 0, responseBytes.Length);

                Console.WriteLine(request);
                Console.WriteLine(new string('=', 60));

            }
        }
    }
}
