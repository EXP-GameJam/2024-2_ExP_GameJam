using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource audioSource;
    public AudioSource SFXSource;
    public List<AudioClip> clipList;
    public Dictionary<string, AudioClip> soundClip = new Dictionary<string, AudioClip>();

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        soundClip.Add("Main", clipList[0]);
        soundClip.Add("Bubble_Pop", clipList[1]);
        soundClip.Add("Death_Breath", clipList[2]);
        soundClip.Add("Door_Bell", clipList[3]);
        soundClip.Add("Door_Knock", clipList[4]);
        soundClip.Add("Door_Slam", clipList[5]);
        soundClip.Add("Ending_Siren", clipList[6]);
        soundClip.Add("Ending_Spy", clipList[7]);
        soundClip.Add("Ending_Wave", clipList[8]);
        soundClip.Add("Ending_Wasted", clipList[9]);
        soundClip.Add("Text_Alarm", clipList[10]);
        soundClip.Add("UI_Button", clipList[11]);
        soundClip.Add("Water_In", clipList[12]);
        soundClip.Add("Water_Out", clipList[13]);
    }

    public void AudioPlay(string audioName)
    {
        audioSource.clip = soundClip[audioName];
        audioSource.Play();
    }

    public void SFXPlay(string SFXName)
    {
        SFXSource.PlayOneShot(soundClip[SFXName]);
    }

    public void ChangeVolume(float value)
    {
        audioSource.volume = value * 0.5f;
        SFXSource.volume = value;
    }
}