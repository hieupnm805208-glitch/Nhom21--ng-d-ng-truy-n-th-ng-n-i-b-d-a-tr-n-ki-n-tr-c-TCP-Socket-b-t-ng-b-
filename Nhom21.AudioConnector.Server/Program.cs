using System.Net;
using System.Net.Sockets;

namespace Nhom21.AudioConnector.Server
{
    class Program
    {
        private static TcpListener _listener;
        private static List<TcpClient> _clients = new List<TcpClient>();
        private const int Port = 8888;

        static async Task Main(string[] args)
        {
            _listener = new TcpListener(IPAddress.Any, Port);
            _listener.Start();
            Console.WriteLine($"[Server] Listening on port {Port}...");

            while (true)
            {
                try
                {
                    var client = await _listener.AcceptTcpClientAsync();
                    lock (_clients)
                    {
                        _clients.Add(client);
                    }
                    Console.WriteLine($"[Server] Client connected from {client.Client.RemoteEndPoint}");
                    _ = HandleClientAsync(client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] Accepting client: {ex.Message}");
                }
            }
        }

        private static async Task HandleClientAsync(TcpClient sourceClient)
        {
            var buffer = new byte[8192]; 
            var stream = sourceClient.GetStream();

            try
            {
                while (sourceClient.Connected)
                {
                    // Read data from source client
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Client disconnected

                    // Relay data to ALL other clients (Broadcast for simplicity in this demo)
                    BroadcastAudio(buffer, bytesRead, sourceClient);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Info] Client disconnected: {ex.Message}");
            }
            finally
            {
                lock (_clients)
                {
                    _clients.Remove(sourceClient);
                }
                sourceClient.Close();
                Console.WriteLine("[Server] Client removed.");
            }
        }

        private static void BroadcastAudio(byte[] data, int length, TcpClient sender)
        {
            lock (_clients)
            {
                // Clean up any disconnected clients found during iteration
                _clients.RemoveAll(c => !c.Connected);

                foreach (var client in _clients)
                {
                    if (client != sender && client.Connected)
                    {
                        try
                        {
                            var stream = client.GetStream();
                            stream.Write(data, 0, length);
                        }
                        catch
                        {
                            // Ignored - client might have just dropped
                        }
                    }
                }
            }
        }
    }
}
