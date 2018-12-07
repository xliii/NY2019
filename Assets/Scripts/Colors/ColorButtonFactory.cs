using UnityEditor;
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
	[Range(2, 4)]
	private int FieldSize = 2;

	[SerializeField]
	[Range(3, 5)]
	private int NumberOfColors = 4;

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
		int size = FieldSize * FieldSize;
		ColorController.Initialize(size);
		for (int i = 0; i < size; i++)
		{
			var colorButton = Instantiate(buttonPrefab, transform);
			colorButton.index = i;
			colorButton.SetColors(ColorSet.GetColors(NumberOfColors));
		}
	}

	private void SetupGrid()
	{
		_grid.constraintCount = FieldSize;
		_grid.cellSize = Vector2.one * (120 - 10 * FieldSize);
	}
}
	