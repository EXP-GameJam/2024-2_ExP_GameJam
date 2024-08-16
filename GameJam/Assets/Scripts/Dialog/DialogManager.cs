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
        Dialog.DialogSettings dialogSettings = new Dialog.DialogSettings();
        dialogSettings.dialogText = "제발 살려줘...";
        dialogSettings.textDelay = 0.25f;
        dialogSettings.isJitter = true;
        dialogSettings.speechBubbleIdx = SpeechBubbleType.Panic;
        CreateDialog(dialogSettings);
    }

    public List<Sprite> speechBubbleImages;
    public List<TMP_FontAsset> Fonts;
    public GameObject dialogPrefab;

    public void CreateDialog(Dialog.DialogSettings dialogSettings)
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
        //dialog.GetComponent<Image>().sprite = speechBubbleImages[(int)dialogSettings.speechBubbleIdx];
        dialog.tmpText.font = Fonts[(int)dialogSettings.fontIdx];
        dialog.tmpText.text = dialogSettings.dialogText;
    }
}
