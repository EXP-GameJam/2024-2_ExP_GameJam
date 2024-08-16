using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
	public void FadeIn(float fadeOutTime)
	{
		StartCoroutine(CoFadeIn(fadeOutTime));
	}

	public void FadeOut(float fadeOutTime)
	{
		StartCoroutine(CoFadeOut(fadeOutTime));
	}
	
	// 불투명 -> 투명
	IEnumerator CoFadeIn(float fadeOutTime)
	{
		Image img = this.gameObject.GetComponent<Image>();
		Color tempColor = img.color;
		tempColor.a = 1.0f;
		while (tempColor.a > 0f)
		{
			tempColor.a -= Time.deltaTime / fadeOutTime;
			img.color = tempColor;

			if (tempColor.a <= 0f) tempColor.a = 0f;

			yield return null;
		}
		img.color = tempColor;
	}

	// 투명 -> 불투명
	IEnumerator CoFadeOut(float fadeOutTime)
	{
		Image img = this.gameObject.GetComponent<Image>();
		Color tempColor = img.color;
		tempColor.a = 0.0f;
		while (tempColor.a < 1f)
		{
			tempColor.a += Time.deltaTime / fadeOutTime;
			img.color = tempColor;

			if (tempColor.a >= 1f) tempColor.a = 1f;

			yield return null;
		}

		img.color = tempColor;

		CutSceneManager.Instance.ShowNextScene();
	}
}
