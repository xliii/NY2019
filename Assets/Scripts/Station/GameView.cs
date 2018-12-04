using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
	[SerializeField]
	private Image _image;
	[SerializeField]
	private Text _label;

	private void SetSprite(Sprite sprite)
	{
		_image.sprite = sprite;
	}

	public void SetText(string text)
	{
		_label.text = text;
	}

	public void SetLevel(Level level)
	{
		SetSprite(level.Image);
		SetText(level.LevelName);
	}
	
}
