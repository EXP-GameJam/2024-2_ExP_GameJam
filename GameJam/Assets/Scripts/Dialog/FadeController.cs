using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
	public bool isCutSceneSkip = false;
	public bool isEndingButton = false;
	public bool isCredit = false;
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

		string nowSceneName = SceneManager.GetActiveScene().name;
		if (nowSceneName == "CutSceneLevel")
        {
			if (isCutSceneSkip || CutSceneManager.Instance.currentSceneIdx == 10)
            {
				isCutSceneSkip = false;
				SceneManager.LoadScene("Main");
            }

            else CutSceneManager.Instance.ShowNextScene();
        }
		else if(nowSceneName == "StartScene")
        {
			AudioManager.Instance.AudioStop();
			SceneManager.LoadScene("CutSceneLevel");
        }
        else if (nowSceneName == "Main")
        {
            SceneManager.LoadScene("EndingScene");
        }
        else if (isCredit && nowSceneName == "EndingScene")
        {
            isCredit = false;
            SceneManager.LoadScene("Credit");
        }
        else if (isEndingButton && nowSceneName == "EndingScene")
        {
			isEndingButton = false;
            SceneManager.LoadScene("StartScene");
        }
		else if (nowSceneName == "Credit")
		{
            SceneManager.LoadScene("StartScene");
        }
    }
}
