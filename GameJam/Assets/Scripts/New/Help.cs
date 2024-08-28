using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Help : MonoBehaviour
{
    public GameObject HelpUI;

    public void HelpOpen()
    {
        AudioManager.Instance.SFXPlay("UI_Button");
        OnHeadClick.isPaused = true;
        Time.timeScale = 0f;
        HelpUI.SetActive(true);
    }


    public void HelpClose()
    {
        AudioManager.Instance.SFXPlay("UI_Button");
        OnHeadClick.isPaused = false;
        HelpUI.SetActive(false);
        Time.timeScale = 1f;
    }


}
