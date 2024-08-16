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
    public Texture speechBubble;
}
