using UnityEngine;

public class ServerStatus : NetworkStatus {

	protected override void Awake() 
	{
		base.Awake();
		Messenger.AddListener(Server.Event.Connected, OnConnect);
		Messenger.AddListener(Server.Event.Disconnected, OnDisconnect);
		Messenger<string>.AddListener(Server.Event.Started, OnStart);
		Messenger<string>.AddListener(Server.Event.MessageReceived, OnMessageReceived);
		SetColor(Color.gray);
	}

	private void OnMessageReceived(string message)
	{
		Debug.Log("Server: Received - " + message, this);
		BlinkColor(Color.white);
	}

	private void OnStart(string ip)
	{
		Debug.Log("Server: Started - " + ip, this);
		SetColor(Color.blue);
	}

	private void OnConnect()
	{
		Debug.Log("Server: Client connected", this);
		SetColor(Color.green);
	}

	private void OnDisconnect()
	{
		Debug.Log("Server: Client disconnected", this);
		SetColor(Color.red);
	}
}
