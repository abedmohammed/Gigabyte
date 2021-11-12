using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInSound : MonoBehaviour {

    public AudioSource sound;
    public AudioLowPassFilter filter;

    public float endVolume;
    public float endFilter;
    public float FadeTime;


	void Start () {

        sound = GetComponent<AudioSource>();
        filter = GetComponent<AudioLowPassFilter>();

	}
	
	void Update () {
		
        //if (sound.volume < endVolume)
        //{
            //sound.volume += endVolume * Time.deltaTime / FadeTime;
        //}

        if (filter.cutoffFrequency < endFilter)
        {
            filter.cutoffFrequency += endFilter * Time.deltaTime / FadeTime;
        }
    }
}
