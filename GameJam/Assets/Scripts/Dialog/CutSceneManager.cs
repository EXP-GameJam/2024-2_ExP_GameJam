using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    private static CutSceneManager _instance;

    public static CutSceneManager Instance
    {
        get
        {
            if(!_instance)
            {
                _instance = FindObjectOfType(typeof(CutSceneManager)) as CutSceneManager;

                if (_instance == null)
                    Debug.Log("No CutSceneManager Object");
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

    }

    public List<CutSceneSettings> cutSceneSettings;
    public GameObject cutScenePrefab;
    public FadeController fader;
    public GameObject BlackPanel;
    public int currentSceneIdx;
    public GameObject CurrentScene;

    public GameObject CreateCutScene(CutSceneSettings cutSceneSetting)
    {
        GameObject newGameObject = Instantiate(cutScenePrefab, new Vector3(0, 0, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
        newGameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        newGameObject.GetComponent<Image>().sprite = cutSceneSetting.cutSceneImage;

        CutScene cutScene = newGameObject.GetComponent<CutScene>();
        cutScene.autoSkipTime = cutSceneSetting.autoSkipTime;
        cutScene.canSkipTime = cutSceneSetting.canSkipTime;
        cutScene.isNextFade = cutSceneSetting.isNextFade;
        cutScene.isNowFade = cutSceneSetting.isNowFade;

        newGameObject.GetComponent<RectTransform>().transform.SetAsFirstSibling();

        return newGameObject;
    }

    private void Start()
    {
        BlackPanel.GetComponent<RectTransform>().transform.SetAsLastSibling();
        BlackPanel.GetComponent<Image>().color = new Color(0,0,0,255);
        fader = BlackPanel.AddComponent<FadeController>();
        currentSceneIdx = 0;

        CurrentScene = CreateCutScene(cutSceneSettings[currentSceneIdx]);
    }

    public void ShowNextScene()
    {
        Destroy(CurrentScene);

        currentSceneIdx++;
        if(cutSceneSettings.Count > currentSceneIdx)
        {
            CurrentScene = CreateCutScene(cutSceneSettings[currentSceneIdx]);
        }
    }

}
