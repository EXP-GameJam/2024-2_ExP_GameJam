using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Help : MonoBehaviour
{
    public GameObject HelpUI;

    public void HelpOpen()
    {
        Time.timeScale = 0f;
        HelpUI.SetActive(true);
    }


    public void HelpClose()
    {
        HelpUI.SetActive(false);
        Time.timeScale = 1f;
    }


}
