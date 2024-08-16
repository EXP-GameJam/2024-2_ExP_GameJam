using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CutScene : MonoBehaviour, IPointerClickHandler
{
    private float flowTime = 0.0f;

    private float autoSkipTime;
    private float canSkipTime;

    public void InitializeCutScene(float _autoSkipTime, float _canSkipTime)
    {
        autoSkipTime = _autoSkipTime;
        canSkipTime = _canSkipTime;
    }

    private void Update()
    {
        flowTime += Time.deltaTime;

        if(flowTime >= autoSkipTime)
        {
            Skip();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        if(flowTime >= canSkipTime)
        {
            Skip();
        }
    }

    private void Skip()
    {
        Debug.Log("Skip");
    }

}
