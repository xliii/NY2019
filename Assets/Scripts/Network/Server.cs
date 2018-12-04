using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class Server : MonoBehaviour
{
	public class Event
	{
		public const string MessageReceived = "e_server_message_received";
		public const string Started = "e_server_started";
		public const string Connected = "e_server_connected";
		public const string Disconnected = "e_server_disconnected";
	}
	
	public int port = 1337;
	public bool initializeOnStart;

	private void Start()
	{
		if (initializeOnStart)
		{
			Initialize();
		}
	}

	public void Initialize()
	{
		NetworkServer.Listen(port);
		NetworkServer.RegisterHandler(MsgType.Connect, _ => Messenger.Broadcast(Event.Connected));
		NetworkServer.RegisterHandler(MsgType.Disconnect, _ => Messenger.Broadcast(Event.Disconnected));
		NetworkServer.RegisterHandler(MsgTypeCustom.Message, OnMessageReceived);
		Messenger<string>.Broadcast(Event.Started, Util.LocalIPAddress());
	}
	
	private void OnMessageReceived(NetworkMessage netmsg)
	{
		var msg = netmsg.ReadMessage<StringMessage>();
		Messenger<string>.Broadcast(Event.MessageReceived, msg.value);
	}
	
	public bool Send(string message)
	{
		return Send(MsgTypeCustom.Message, message);
	}

	public bool Send(short msgType, string message)
	{
		return NetworkServer.SendToAll(msgType, new StringMessage(message));
	}
}
