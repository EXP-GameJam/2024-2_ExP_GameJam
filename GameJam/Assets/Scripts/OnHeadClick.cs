using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void Awake()
    {
        StartCoroutine(Timer());
    }

    public static void Rese222()
    {
        HeadDown = null;
        HeadUp = null;
    }

    public static void Enable() => isDisabled = false;

    public static void Disable() => isDisabled = true;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isDisabled) return;
        if (isPaused) return;
        HeadDown();
        AudioManager.Instance.SFXPlay("Water_In");
        isDowned = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isDowned) return;
        HeadUp();
        AudioManager.Instance.SFXPlay("Water_Out");
        isDowned = false;
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        isPaused = true;
        yield return new WaitForSeconds(2);
        isPaused = false;
    }
}
