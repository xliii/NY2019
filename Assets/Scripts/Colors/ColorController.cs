using System.Linq;
using Boo.Lang.Runtime;
using UnityEngine;

[RequireComponent(typeof(Server))]
public class ColorController : MonoBehaviour {

	public class Event
	{
		public static string ColorChanged = "e_color_changed";
	}

	private Server server;

	private const char EMPTY = '-';

	private char[] _colors;
	
	void Awake ()
	{
		server = GetComponent<Server>();
		Messenger<int, char>.AddListener(Event.ColorChanged, OnColorChanged);
	}

	public void Initialize(int size)
	{
		_colors = Enumerable.Repeat(EMPTY, size).ToArray();
	}

	private void OnColorChanged(int index, char color)
	{
		if (index >= _colors.Length)
		{
			throw new RuntimeException("Color out of range. Size: " + _colors.Length + ", Actual: " + index);
		}
		
		_colors[index] = color;
		if (IsValid())
		{
			var message = new string(_colors);
			Debug.Log("Sending colors: " + message);
			server.Send(message);
		};
	}

	private bool IsValid()
	{
		return _colors.All(c => c != EMPTY);
	}
}
