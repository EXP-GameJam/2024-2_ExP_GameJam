using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public float textDelay;
    public int EndingNum;
    public GameObject BlackPanel;
    public FadeController fader;
    private string text;

    public Button returnButton;
    public GameObject EndingImageObject;

    private string[] EndingText = { 
    "Ending 1/4\n\n~경찰서 엔딩~",
    "Ending 2/4\n\n~기절 엔딩~",
    "Ending 3/4\n\n~새출발 엔딩~",
    "Ending 4/4\n\n~국정원 취업 엔딩~"};

    public List<Sprite> EndingImages;

    private void Start()
    {
        EndingNum = 1;

        EndingImageObject.GetComponent<Image>().sprite = EndingImages[EndingNum];
        EndingImageObject.SetActive(false);
        returnButton.gameObject.SetActive(false);

        tmpText.text = EndingText[EndingNum];
        text = tmpText.text.ToString();
        tmpText.text = "";

        BlackPanel.GetComponent<RectTransform>().transform.SetAsLastSibling();
        BlackPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        fader = BlackPanel.AddComponent<FadeController>();

        StartCoroutine(TextPrint(textDelay));
    }

    IEnumerator TextPrint(float delay)
    {
        int count = 0;

        while(count != text.Length)
        {
            if(count < text.Length)
            {
                tmpText.text += text[count].ToString();
                count++;
            }

            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(5.0f);
        fader.FadeOut(0.5f);

        yield return new WaitForSeconds(0.5f);
        ShowResultImage();
    }

    private void ShowResultImage()
    {
        fader.FadeIn(0.5f);
        tmpText.gameObject.SetActive(false);

        EndingImageObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
    }

    public void MainButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
