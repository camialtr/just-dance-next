using System;
using System.Net;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Sockets;

public static class Dancer01Server
{
    private static TcpListener tcpListener;
    private static TcpClient tcpClient;
    private static Thread listenerThread;
    private static string localIP;

    public static bool connected = false;
    public static bool breakThread = false;
    public static bool threadBreaked = false;
    public static NetworkData networkData;

    public static void Connect(string ip)
    {
        localIP = ip;
        listenerThread = new(new ThreadStart(Listen))
        {
            IsBackground = true
        };
        listenerThread.Start();
    }

    public static void Disconnect()
    {
        listenerThread.Abort();
        threadBreaked = false;
    }

    private static void Listen()
    {
        try
        {
            tcpListener = new TcpListener(IPAddress.Parse(localIP), 13001);
            tcpListener.Start();
            Debug.Log("Server is listening");
            byte[] bytes = new byte[100];
            while (true)
            {
                using (tcpClient = tcpListener.AcceptTcpClient())
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
                            Debug.Log(clientMessage);
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

    public static void SendMessage()
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
    public uint selectedCoach;
}