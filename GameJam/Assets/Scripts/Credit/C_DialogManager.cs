using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class C_DialogManager : MonoBehaviour
{
    private static C_DialogManager _instance;

    public static C_DialogManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(C_DialogManager)) as C_DialogManager;

                if (_instance == null)
                    Debug.Log("No Singleton Object");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        C_OnHeadClick.HeadDown += HeadDown;
    }


    public void HeadDown() => Destroy(newGameObject);


    public List<Sprite> speechBubbleImages;
    public TMP_FontAsset DNFFont;
    public GameObject dialogPrefab;
    public GameObject dialogParent;
    public Color[] color = { new Color(0, 0, 0), new Color(0, 24, 103), new Color(156, 0, 40), new Color(112, 0, 112) };

    GameObject newGameObject;
    public void CreateDialog(DialogSettings dialogSettings)
    {
        newGameObject = Instantiate(dialogPrefab, new Vector3(0, 0, 0), Quaternion.identity, dialogParent.transform);
        newGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -500);
        
        GameObject childText = newGameObject.transform.GetChild(0).gameObject;
        VertexJitter jitter = childText.AddComponent<VertexJitter>();

        Animator speechBubbleAnims = newGameObject.GetComponent<Animator>();
        speechBubbleAnims.SetInteger("SpeechBubbleIdx", (int)dialogSettings.speechBubbleIdx);

        Dialog dialog = newGameObject.GetComponent<Dialog>();
        dialog.tmpText.font = DNFFont;
        dialog.textDelay = 0.15f;
        dialog.tmpText.text = dialogSettings.dialogText;
        dialog.tmpText.color = color[(int)dialogSettings.color];
    }
}
