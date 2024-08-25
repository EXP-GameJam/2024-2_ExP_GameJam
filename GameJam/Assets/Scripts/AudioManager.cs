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
        soundClip.Add("Bubble_Pop_01", clipList[1]);
        soundClip.Add("Bubble_Pop_02", clipList[2]);
        soundClip.Add("Bubble_Pop_03", clipList[3]);
        soundClip.Add("Death_Breath", clipList[4]);
        soundClip.Add("Door_Bell", clipList[5]);
        soundClip.Add("Door_Knock", clipList[6]);
        soundClip.Add("Door_Slam", clipList[7]);
        soundClip.Add("Ending_Siren", clipList[8]);
        soundClip.Add("Ending_Spy", clipList[9]);
        soundClip.Add("Ending_Wave", clipList[10]);
        soundClip.Add("Ending_Wasted", clipList[11]);
        soundClip.Add("Text_Alarm", clipList[12]);
        soundClip.Add("UI_Button", clipList[13]);
        soundClip.Add("Water_In", clipList[14]);
        soundClip.Add("Water_Out", clipList[15]);
        soundClip.Add("Start_Siren", clipList[16]);
    }

    public void AudioPlay(string audioName)
    {
        audioSource.clip = soundClip[audioName];
        audioSource.Play();
    }

    public void AudioStop()
    {
        audioSource.Stop();
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