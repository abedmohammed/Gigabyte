using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeMusicVolume : MonoBehaviour {

    public AudioMixer audioMixer;

    public void Awake()
    {
        float volume = PlayerPrefs.GetFloat("volume");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }

}
