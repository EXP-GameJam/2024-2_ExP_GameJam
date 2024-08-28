using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;
    void OnEnable()
    {
        slider.value = AudioManager.Instance.SFXSource.volume;
        slider.onValueChanged.AddListener(delegate { ChangeVolume(slider.value); });
    }

    void ChangeVolume(float value)
    {
        AudioManager.Instance.ChangeVolume(value);
    }

    void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }
}