using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Component.GenericReader
{
    public class AsynchronousSocketListener
    {
        public async Task StartListening()
        {
            var listener = new TcpListener(IPAddress.Any, 11001);

            try
            {
                listener.Start();

                while (true)
                {
                    await AcceptClientsAsync(listener);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                listener.Stop();
            }
            Console.Read();
        }

        async Task AcceptClientsAsync(TcpListener listener)
        {
            TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
            await ReceiveAsync(client);
        }

        async Task ReceiveAsync(TcpClient client)
        {
            using (client)
            {
                var buffer = new byte[1024];
                var stream = client.GetStream();
                var timeout = Task.Delay(TimeSpan.FromSeconds(10));
                var readTask = stream.ReadAsync(buffer, 0, buffer.Length);
                var completedTask = await Task.WhenAny(timeout, readTask).ConfigureAwait(false);
                if (completedTask == timeout)
                    return;
                var response = HandleRead.Process(Encoding.UTF8.GetString(buffer, 0, readTask.Result));
                await SendAsync(stream, response);
            }
        }    

        async Task SendAsync(NetworkStream stream, string data)
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            await stream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
        }
    }
}
