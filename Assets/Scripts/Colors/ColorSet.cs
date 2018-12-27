using System.Collections.Generic;
using System.Linq;
using Boo.Lang.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSet", menuName = "Color/Create Set")]
public class ColorSet : ScriptableObject
{
	[SerializeField]
	private NamedColor[] Colors;

	public NamedColor[] GetColors(string colors)
	{
		if (colors.Length > Colors.Length)
		{
			throw new RuntimeException("Out of range: Size: " + Colors.Length + ", Requested: " + colors.Length);
		}

		List<NamedColor> list = new List<NamedColor>();
		foreach (var color in colors)
		{
			list.Add(Colors.First(c => c.code == color));
		}

		return list.ToArray();
	}
}
