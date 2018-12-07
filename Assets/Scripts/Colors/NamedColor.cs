using UnityEngine;

[CreateAssetMenu(fileName = "Color", menuName = "Color/Create Color")]
public class NamedColor : ScriptableObject
{
	public char code;
	public Color color;
}
