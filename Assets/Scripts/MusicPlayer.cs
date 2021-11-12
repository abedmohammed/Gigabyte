using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private static MusicPlayer music;
    public bool keep;

    // Use this for initialization
    void Awake()
    {

        DontDestroyOnLoad(gameObject);
        if (music == null || keep)
        {
            music = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyObject(gameObject);
            return;
        }

    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
