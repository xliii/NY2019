using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Server))]
public class ColorController : MonoBehaviour {

	public class Event
	{
		public static string ColorChanged = "e_color_changed";
	}

	private Server server;

	private const char EMPTY = '-';

	private char[] colors = {EMPTY, EMPTY, EMPTY, EMPTY};
	
	void Awake ()
	{
		server = GetComponent<Server>();
		Messenger<int, char>.AddListener(Event.ColorChanged, OnColorChanged);
	}

	private void OnColorChanged(int index, char color)
	{
		colors[index] = color;
		if (IsValid())
		{
			var message = new string(colors);
			Debug.Log("Sending colors: " + message);
			server.Send(message);
		};
	}

	private bool IsValid()
	{
		return colors.All(c => c != EMPTY);
	}
}
