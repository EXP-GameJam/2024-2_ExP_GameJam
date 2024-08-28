using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject SettingUI;

    public void SettingOpen()
    {
        AudioManager.Instance.SFXPlay("UI_Button");
        OnHeadClick.isPaused = true;
        Time.timeScale = 0f;
        SettingUI.SetActive(true);
    }


    public void SettingClose()
    {
        AudioManager.Instance.SFXPlay("UI_Button");
        OnHeadClick.isPaused = false;
        SettingUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Main()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.SFXPlay("UI_Button");
        OnHeadClick.ResetGame();
        SceneManager.LoadScene("StartScene");
    }

    public void Quit()
    {
        AudioManager.Instance.SFXPlay("UI_Button");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
