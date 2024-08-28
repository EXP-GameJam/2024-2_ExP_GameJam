using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skippppp : MonoBehaviour
{
    public void Skipppppp()
    {
        AudioManager.Instance.SFXPlay("UI_Button");
        CutSceneManager.Instance.fader.isCutSceneSkip = true;
        CutSceneManager.Instance.fader.FadeOut(0.5f);
    }
}
