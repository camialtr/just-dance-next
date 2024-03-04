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
    public bool newInput;

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
        try
        {
            tcpClient.Close();
        }
        catch { }
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
                            newInput = true;
                        }
                        catch { }
                        if (!connected) { connected = true; }
                        if (breakThread)
                        {
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
    }

    public void SendMessage()
    {
        if (tcpClient == null) { return; }
        try
        {
            NetworkStream stream = tcpClient.GetStream();
            if (stream.CanWrite)
            {
                string networkMessage = "";
                byte[] message = Encoding.UTF8.GetBytes(networkMessage);
                stream.Write(message, 0, message.Length);
            }
        }
        catch (SocketException socketException)
        {
            Debug.LogError("SocketException " + socketException.ToString());
        }
    }
}

public struct NetworkData
{
    public float x;
    public float y;
    public float z;
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