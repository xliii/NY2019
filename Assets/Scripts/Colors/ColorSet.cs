using System.Linq;
using Boo.Lang.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSet", menuName = "Color/Create Set")]
public class ColorSet : ScriptableObject
{
	[SerializeField]
	private NamedColor[] Colors;

	public NamedColor[] GetColors(int size)
	{
		if (size > Colors.Length)
		{
			throw new RuntimeException("Out of range: Size: " + Colors.Length + ", Requested: " + size);
		}

		return Colors.Take(size).ToArray();
	}
}
