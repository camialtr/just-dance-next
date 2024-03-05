using System;
using System.Net;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;

public static class Server
{
    public static int mainDancer = -1;
    public static DancerServer[] Dancer = new DancerServer[4] { new(), new(), new(), new() };
}

public class DancerServer
{
    private TcpListener tcpListener;
    private TcpClient tcpClient;
    private Thread listenerThread;
    private string localIP;
    private int localPort;

    public bool connected = false;
    public bool breakThread = false;
    public bool threadBreaked = false;
    public bool isQuitting = false;

    public NetworkData networkData;

    public void Connect(string ip, int playerIndex)
    {
        localIP = ip;
        localPort = 13000 + playerIndex;
        listenerThread = new(new ThreadStart(Listen))
        {
            IsBackground = true
        };
        listenerThread.Start();
    }

    public void Disconnect()
    {
        tcpListener.Stop();
        listenerThread.Abort();
        threadBreaked = false;
    }

    private async void Listen()
    {
        try
        {
            tcpListener = new TcpListener(IPAddress.Parse(localIP), localPort);
            tcpListener.Start();
            byte[] bytes = new byte[100];
            while (true)
            {
                using (tcpClient = await tcpListener.AcceptTcpClientAsync())
                {
                    using NetworkStream stream = tcpClient.GetStream();
                    int length;
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        byte[] incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        string clientMessage = Encoding.UTF8.GetString(incommingData);
                        try
                        {
                            networkData = JsonConvert.DeserializeObject<NetworkData>(clientMessage.Replace("*", ""));
                            //Debug.LogError(clientMessage);                            
                        }
                        catch { }
                        if (!connected) { SendMessage("0"); connected = true; }
                        if (breakThread)
                        {
                            SendMessage("1");
                            break;
                        }
                    }
                    if (breakThread)
                    {
                        tcpListener.Stop();
                        tcpClient.Close();
                        connected = false;
                        breakThread = false;
                        threadBreaked = true;
                        break;
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.LogError("SocketException " + socketException.ToString());
        }
        catch (ObjectDisposedException disposedException) { }
    }

    public void SendMessage(string networkMessage)
    {
        if (tcpClient == null) { return; }
        try
        {
            NetworkStream stream = tcpClient.GetStream();
            if (stream.CanWrite)
            {
                byte[] message = Encoding.UTF8.GetBytes(networkMessage);
                stream.Write(message, 0, message.Length);
            }
        }
        catch (SocketException socketException)
        {
            Debug.LogError("SocketException " + socketException.ToString());
        }
        catch (ObjectDisposedException disposedException) { }
    }
}

public struct NetworkData
{
    public float x;
    public float y;
    public float z;
    public bool newInput;
    public NetworkInput networkInput;
}

public enum NetworkInput
{
    None,
    Undo,
    Select,
    Up,
    Down,
    Left,
    Right
}