using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        CreateDialog(new Dialog.DialogSettings());
    }

    public List<Sprite> speechBubbleImages;
    public List<TMP_FontAsset> Fonts;
    public GameObject dialogPrefab;
    public GameObject dialogParent;

    public void CreateDialog(Dialog.DialogSettings dialogSettings)
    {
        GameObject newGameObject = Instantiate(dialogPrefab, new Vector3(0, 0, 0), Quaternion.identity, dialogParent.transform);
        newGameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        Dialog dialog = newGameObject.GetComponent<Dialog>();

        dialog.GetComponent<Image>().sprite = speechBubbleImages[(int)dialogSettings.speechBubbleIdx];
        dialog.tmpText.font = Fonts[(int)dialogSettings.fontIdx];
    }
}
