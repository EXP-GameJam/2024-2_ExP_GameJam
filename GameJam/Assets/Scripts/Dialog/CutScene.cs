using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[System.Serializable]
public class CutSceneSettings
{
    public float autoSkipTime;
    public float canSkipTime;
    public bool isNextFade;
    public bool isNowFade;
    public Sprite cutSceneImage;
}

public class CutScene : MonoBehaviour, IPointerClickHandler
{
    private float flowTime = 0.0f;
    private bool isSkipped = false;

    public bool isNowFade;
    public bool isNextFade;
    public float autoSkipTime;
    public float canSkipTime;

    private void Update()
    {
        flowTime += Time.deltaTime;

        if(flowTime >= autoSkipTime && !isSkipped)
        {
            Skip();
            isSkipped = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        if(flowTime >= canSkipTime && !isSkipped)
        {
            Skip();
            isSkipped = true;
        }
    }

    private void Start()
    {
        if(isNowFade)
        {
            CutSceneManager.Instance.fader.FadeIn(0.5f);
        }
    }

    private void Skip()
    {
        if(isNextFade)
        {
            CutSceneManager.Instance.fader.FadeOut(0.5f);
        }
        else
        {
            CutSceneManager.Instance.ShowNextScene();
        }
    }
}