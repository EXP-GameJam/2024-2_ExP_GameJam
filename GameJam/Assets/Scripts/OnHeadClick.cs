using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHeadClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public delegate void headDown();
    public static event headDown HeadDown;
    public delegate void headUp();
    public static event headUp HeadUp;

    public static bool isDisabled = false;

    public static void Disable()
    {
        isDisabled = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isDisabled) HeadDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        HeadUp();
    }
}
