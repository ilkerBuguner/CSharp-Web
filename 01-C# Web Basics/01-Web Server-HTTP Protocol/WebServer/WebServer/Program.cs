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
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        static async Task Main(string[] args)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Task.Run(async () =>
                {
                    TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                    await ProcessClientAsync(tcpClient);
                });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            }
        }

        private static async Task
            ProcessClientAsync(TcpClient tcpClient)
        {
            const string NewLine = "\r\n";

            using NetworkStream networkStream = tcpClient.GetStream();
            byte[] requestedBytes = new byte[1000000];
            int bytesRead = await networkStream.ReadAsync(requestedBytes, 0, requestedBytes.Length);
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


            response = response + NewLine + DateTime.UtcNow.ToString();
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);

            Console.WriteLine(request);
            Console.WriteLine(new string('=', 60));
        }
    }
}
