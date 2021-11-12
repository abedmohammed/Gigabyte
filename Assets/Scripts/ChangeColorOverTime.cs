using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOverTime : MonoBehaviour {

    float duration = 1f;

    private float t = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.white, t);

        if (t < 1)
        {
            t += Time.deltaTime / duration;
        }

    }
}
