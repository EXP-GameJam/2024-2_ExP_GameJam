using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public struct DialogSettings
    {
        public string dialogText;
        public int speechBubbleIdx;
        public int fontIdx;
        public Vector2 dialogVector;

        public DialogSettings(string _dialogText = "", int _speechBubbleIdx = 0, int _fondIdx = 0)
        {
            this.dialogText = _dialogText;
            this.speechBubbleIdx = _speechBubbleIdx;
            this.fontIdx = _fondIdx;
            this.dialogVector = Vector2.zero;
        }
    }

    // TextBox
    // DialogBox
    // Font


}
