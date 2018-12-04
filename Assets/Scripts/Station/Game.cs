using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] 
	private GameView _view;

	[SerializeField]
	private Level _level;

	private void Awake()
	{
		Messenger<string>.AddListener(Client.Event.MessageReceived, OnMessageReceived);
	}

	private void Start()
	{
		UpdateView();
	}

	private void OnMessageReceived(string code)
	{
		if (_level.PassCode == code)
		{
			NextLevel();
		}
	}

	private void NextLevel()
	{
		_view.SetText("VICTORY!");
	}

	private void UpdateView()
	{
		_view.SetLevel(_level);
	}

	public void SetLevel(Level level)
	{
		_level = level;
		UpdateView();
	}
}
