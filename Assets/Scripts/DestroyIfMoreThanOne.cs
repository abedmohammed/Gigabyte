using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfMoreThanOne : MonoBehaviour {

    GameObject[] noises;

    // Use this for initialization
    void Start () {

        noises = GameObject.FindGameObjectsWithTag("ChargeAudio");

        if(noises.Length > 1)
        {
            DestroyObject(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
