using UnityEngine;

public class ClientStatus : NetworkStatus {

	protected override void Awake ()
	{
		base.Awake();
		Messenger.AddListener(Client.Event.Connected, OnConnect);
		Messenger.AddListener(Client.Event.Disconnected, OnDisconnect);
		Messenger<string>.AddListener(Client.Event.MessageReceived, OnMessageReceived);
		SetColor(Color.gray);
	}
	
	private void OnMessageReceived(string message)
	{
		Debug.Log("Client: Received - " + message, this);
		BlinkColor(Color.white);
	}

	private void OnConnect()
	{
		Debug.Log("Client: Connected to server", this);
		SetColor(Color.green);
	}

	private void OnDisconnect()
	{
		Debug.Log("Client: Disconnected to server", this);
		SetColor(Color.red);
	}
}
