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

        OnHeadClick.HeadDown += HeadDown;
    }

    /*private void Start()
    {
        // Text 예시
        DialogSettings dialogSettings = new DialogSettings();
        dialogSettings.dialogText = "나는 아무것도 몰라";
        dialogSettings.textDelay = 1.3f;
        dialogSettings.isJitter = false;
        dialogSettings.speechBubbleIdx = SpeechBubbleType.Normal;
        CreateDialog(dialogSettings);
    }*/



    public void HeadDown() => Destroy(newGameObject);


    public List<Sprite> speechBubbleImages;
    public List<TMP_FontAsset> Fonts;
    public GameObject dialogPrefab;
    public GameObject dialogParent;
    public Color[] color = { Color.blue, Color.red, Color.black };

    GameObject newGameObject;
    public void CreateDialog(DialogSettings dialogSettings)
    {
        newGameObject = Instantiate(dialogPrefab, new Vector3(0, 0, 0), Quaternion.identity, dialogParent.transform);
        newGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -500);
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
        dialog.tmpText.color = color[(int)dialogSettings.color];
    }
}
