using System.Collections.Generic;
using System.Linq;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorButton : MonoBehaviour
{
	public int index;

	private Dictionary<char, Color> colors = new Dictionary<char, Color>();

	private Image image;

	private const int UNDEFINED = -1;

	private int selectedColor = UNDEFINED;

	private void Awake()
	{
		image = GetComponent<Image>();
	}

	private void Start()
	{
		colors['R'] = fromHex("#FD3131");
		colors['B'] = fromHex("#1ACA1A");
		colors['G'] = fromHex("#2D2DD4");
		colors['Y'] = fromHex("#D1C42C");
	}

	private Color fromHex(string color)
	{
		Color output;
		if (!ColorUtility.TryParseHtmlString(color, out output))
		{
			throw new RuntimeException("Could not parse color: " + color);
		}

		return output;
	}

	public void CycleColors()
	{
		selectedColor = (selectedColor + 1) % colors.Count;
		var key = colors.Keys.ElementAt(selectedColor);
		image.color = colors[key];
		Messenger<int, char>.Broadcast(ColorController.Event.ColorChanged, index, key);
	}
}
