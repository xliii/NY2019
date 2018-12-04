using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class Client : MonoBehaviour
{
    public class Event
    {
        public const string MessageReceived = "e_client_message_received";
        public const string Connected = "e_client_connected";
        public const string Disconnected = "e_client_disconnected";
    }
    
    public string host = "192.168.11.37";
    public int port = 1337;
    public bool InitializeOnStart;

    private NetworkClient client;

    private void Start()
    {
        if (InitializeOnStart)
        {
            Initialize();
        }
    }
    
    public void Initialize()
    {
        client = new NetworkClient();
        client.RegisterHandler(MsgType.Connect, _ => Messenger.Broadcast(Event.Connected));
        client.RegisterHandler(MsgType.Disconnect, _ => Messenger.Broadcast(Event.Disconnected));
        client.RegisterHandler(MsgTypeCustom.Message, OnMessageReceived);
        client.Connect(host, port);
    }

    private void OnMessageReceived(NetworkMessage netmsg)
    {
        var msg = netmsg.ReadMessage<StringMessage>();
        Messenger<string>.Broadcast(Event.MessageReceived, msg.value);
    }

    public bool Send(string message)
    {
        return client.Send(MsgTypeCustom.Message, new StringMessage(message));
    }
}
