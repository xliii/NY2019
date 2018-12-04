using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level/Create", order = 1)]
public class Level : ScriptableObject
{

	public string LevelName;
	public string PassCode;
	public Sprite Image;

}
