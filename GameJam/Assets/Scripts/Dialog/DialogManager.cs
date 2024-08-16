using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private static DialogManager _instance;

    public static DialogManager Instance
    {
        get
        {
            if(!_instance)
            {
                _instance = FindObjectOfType(typeof(DialogManager)) as DialogManager;

                if (_instance == null)
                    Debug.Log("No Singleton Object");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }

        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Text 예시
        DialogSettings dialogSettings = new DialogSettings();
        dialogSettings.dialogText = "나는 아무것도 몰라";
        dialogSettings.textDelay = 1.3f;
        dialogSettings.isJitter = false;
        dialogSettings.speechBubbleIdx = SpeechBubbleType.Normal;
        CreateDialog(dialogSettings);
    }

    public List<Sprite> speechBubbleImages;
    public List<TMP_FontAsset> Fonts;
    public GameObject dialogPrefab;

    public void CreateDialog(DialogSettings dialogSettings)
    {
        GameObject newGameObject = Instantiate(dialogPrefab, new Vector3(0, 0, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
        newGameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        if(dialogSettings.isJitter)
        {
            GameObject childText = newGameObject.transform.GetChild(0).gameObject;
            VertexJitter jitter = childText.AddComponent<VertexJitter>();
        }

        Animator speechBubbleAnims = newGameObject.GetComponent<Animator>();
        speechBubbleAnims.SetInteger("SpeechBubbleIdx", (int)dialogSettings.speechBubbleIdx);

        Dialog dialog = newGameObject.GetComponent<Dialog>();
        dialog.tmpText.font = Fonts[(int)dialogSettings.fontIdx];
        dialog.textDelay = dialogSettings.textDelay;
        dialog.tmpText.text = dialogSettings.dialogText;
    }
}
