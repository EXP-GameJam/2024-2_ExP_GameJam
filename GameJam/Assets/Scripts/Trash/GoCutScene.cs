using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoCutScene : MonoBehaviour, IPointerClickHandler
{
    public FadeController fader;
    public GameObject BlackPanel;

    private void Start()
    {
        AudioManager.Instance.AudioPlay("Main");
        BlackPanel.GetComponent<RectTransform>().transform.SetAsLastSibling();
        BlackPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        fader = BlackPanel.AddComponent<FadeController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Instance.SFXPlay("UI_Button");
        fader.FadeOut(0.5f);
    }
}
