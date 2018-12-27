using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level/Create")]
public class Level : ScriptableObject
{

	public string LevelName;
	[Range(2, 4)]
	public int Size;
	
	public string Colors;
	public string PassCode;
	public Sprite Image;

}
