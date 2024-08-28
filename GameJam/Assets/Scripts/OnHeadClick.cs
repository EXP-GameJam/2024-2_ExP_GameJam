using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHeadClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public delegate void headDown();
    public static event headDown HeadDown;
    public delegate void headUp();
    public static event headUp HeadUp;

    public static bool isDisabled = false;
    public static bool isPaused = false;
    public static bool isDowned = false;

    public static FadeController fader;
    public GameObject BlackPanel;

    private void Start()
    {
        BlackPanel.GetComponent<RectTransform>().transform.SetAsLastSibling();
        BlackPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        fader = BlackPanel.AddComponent<FadeController>();
        fader.FadeIn(0.5f);

        AudioManager.Instance.SFXPlay("Start_Siren");
        StartCoroutine(Timer());
    }

    public static void End() => fader.FadeOut(0.5f);

    public static void ResetGame()
    {
        TimeAttack.isDisabled = false;
        isDisabled = false;
        isPaused = false;
        isDowned = false;
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
        yield return new WaitForSeconds(1);
        isPaused = false;
    }
}
