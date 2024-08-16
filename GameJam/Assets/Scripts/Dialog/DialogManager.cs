using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public List<Texture> dialogBoxImages;
    public List<TMP_FontAsset> Fonts;
    public GameObject dialogPrefab;

    public void CreateDialog(Dialog.DialogSettings dialogSettings)
    {
        Instantiate(dialogPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
