using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class ColorButtonFactory : MonoBehaviour
{
	[SerializeField]
	private ColorButton buttonPrefab;
	
	[SerializeField]
	private ColorController ColorController;

	[SerializeField]
	private ColorSet ColorSet;

	[SerializeField]
	private Level Level;

	private GridLayoutGroup _grid;

	private void Awake()
	{
		_grid = GetComponent<GridLayoutGroup>();
		Generate();
	}

	private void ClearChildren()
	{
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}
	}

	public void Generate()
	{
		ClearChildren();
		SetupGrid();
		int size = Level.Size * Level.Size;
		ColorController.Initialize(size);
		for (int i = 0; i < size; i++)
		{
			var colorButton = Instantiate(buttonPrefab, transform);
			colorButton.index = i;
			colorButton.SetColors(ColorSet.GetColors(Level.Colors));
		}
	}

	private void SetupGrid()
	{
		_grid.constraintCount = Level.Size;
		_grid.cellSize = Vector2.one * (120 - 10 * Level.Size);
	}
}
	