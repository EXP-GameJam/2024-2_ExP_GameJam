using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class DialogSettings
{
    public string dialogText;
    public SpeechBubbleType speechBubbleIdx;
    public ColorType color;

    public DialogSettings(string _dialogText = "", SpeechBubbleType _speechBubbleIdx = 0, ColorType _color = 0)
    {
        this.dialogText = _dialogText;
        this.speechBubbleIdx = _speechBubbleIdx;
        this.color = _color;
    }
}

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public float textDelay;
    private string text;

    private void Start()
    {
        text = tmpText.text.ToString();
        tmpText.text = "";

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
    }
}
