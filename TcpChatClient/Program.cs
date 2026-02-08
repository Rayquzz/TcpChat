using System.Net.Sockets;
using System.Text;

string serverIp = "127.0.0.1";
int port = 5000;

// Creăm clientul TCP
TcpClient client = new TcpClient();
client.Connect(serverIp, port);

Console.WriteLine("[CLIENT] Conectat la server");

NetworkStream stream = client.GetStream();

// Task separat pentru primirea mesajelor
Task.Run(() => ReceiveMessages(stream));

// Trimitem mesaje către server
while (true)
{
    string message = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(message))
        continue;

    byte[] data = Encoding.UTF8.GetBytes(message);
    stream.Write(data, 0, data.Length);
}

// Primește mesaje de la server
void ReceiveMessages(NetworkStream stream)
{
    byte[] buffer = new byte[1024];

    try
    {
        while (true)
        {
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            if (bytesRead == 0)
                break;

            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"[MESAJ] {message}");
        }
    }
    catch
    {
        Console.WriteLine("[CLIENT] Deconectat");
    }
}