using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public struct DialogSettings
    {
        public string dialogText;
        public SpeechBubbleType speechBubbleIdx;
        public FontType fontIdx;
        public Vector3 dialogVector;

        public DialogSettings(string _dialogText = "", SpeechBubbleType _speechBubbleIdx = 0, FontType _fondIdx = 0)
        {
            this.dialogText = _dialogText;
            this.speechBubbleIdx = _speechBubbleIdx;
            this.fontIdx = _fondIdx;
            this.dialogVector = Vector3.zero;
        }
    }

    public TextMeshProUGUI tmpText;

    private string text;
    private float textDelay = 0.1f;

    private void Start()
    {
        text = tmpText.text.ToString();
        tmpText.text = "";

        StartCoroutine(textPrint(textDelay));
    }

    IEnumerator textPrint(float delay)
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
