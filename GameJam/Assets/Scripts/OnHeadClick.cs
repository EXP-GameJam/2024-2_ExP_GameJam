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
    public static bool isPaused = false;
    public static bool isDowned = false;

    public static void Disable()
    {
        isDisabled = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isDisabled) return;
        if (isPaused) return;
        HeadDown();
        isDowned = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isDowned) return;
        HeadUp();
        isDowned = false;
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        isPaused = true;
        yield return new WaitForSeconds(3);
        isPaused = false;
    }
}
