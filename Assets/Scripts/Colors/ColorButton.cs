using Boo.Lang.Runtime;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorButton : MonoBehaviour
{
	public int index;

	private NamedColor[] _colors;

	private Image image;

	private const int UNDEFINED = -1;

	private int selectedColor = UNDEFINED;

	private void Awake()
	{
		image = GetComponent<Image>();
	}

	public void SetColors(NamedColor[] colors)
	{
		_colors = colors;
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
		selectedColor = (selectedColor + 1) % _colors.Length;
		var color = _colors[selectedColor];
		image.color = color.color;
		Messenger<int, char>.Broadcast(ColorController.Event.ColorChanged, index, color.code);
	}
}
