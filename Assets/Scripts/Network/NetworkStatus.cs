using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class NetworkStatus : MonoBehaviour
{
	private Image icon;

	protected virtual void Awake()
	{
		icon = GetComponent<Image>();
	}

	protected void SetColor(Color color)
	{
		icon.color = color;
	}

	protected void BlinkColor(Color color, float duration = 0.35f)
	{
		StartCoroutine(BlinkCoroutine(color, icon.color, duration));
	}
	
	private IEnumerator BlinkCoroutine(Color target, Color initial, float duration)
	{
		SetColor(target);
		yield return new WaitForSeconds(duration);
		SetColor(initial);
	}

}
