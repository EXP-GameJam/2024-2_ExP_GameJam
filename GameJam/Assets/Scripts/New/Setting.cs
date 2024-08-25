using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Setting : MonoBehaviour
{
    public GameObject SettingUI;

    public void SettingOpen()
    {
        Time.timeScale = 0f;
        SettingUI.SetActive(true);
    }


    public void SettingClose()
    {
        SettingUI.SetActive(false);
        Time.timeScale = 1f;
    }


}
