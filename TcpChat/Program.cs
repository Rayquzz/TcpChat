using System.Net;
using System.Net.Sockets;
using System.Text;

// Lista de clienți conectați
List<TcpClient> clients = new();

// Portul pe care ascultă serverul
int port = 5000;

// Creăm serverul TCP
TcpListener server = new TcpListener(IPAddress.Any, port);
server.Start();

Console.WriteLine($"[SERVER] Pornit pe portul {port}");

// Serverul rulează permanent
while (true)
{
    // Acceptă un client nou
    TcpClient client = server.AcceptTcpClient();
    clients.Add(client);

    Console.WriteLine("[SERVER] Client conectat");

    // Pornim un task separat pentru client
    Task.Run(() => HandleClient(client));
}

// Funcția care gestionează un client
void HandleClient(TcpClient client)
{
    try
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];

        while (true)
        {
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            // Clientul s-a deconectat
            if (bytesRead == 0)
                break;

            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"[CLIENT] {message}");

            Broadcast(message);
        }
    }
    catch
    {
        Console.WriteLine("[SERVER] Eroare client");
    }
    finally
    {
        clients.Remove(client);
        client.Close();
        Console.WriteLine("[SERVER] Client deconectat");
    }
}

// Trimite mesajul la toți clienții
void Broadcast(string message)
{
    byte[] data = Encoding.UTF8.GetBytes(message);

    foreach (var c in clients)
    {
        try
        {
            NetworkStream stream = c.GetStream();
            stream.Write(data, 0, data.Length);
        }
        catch { }
    }
}