using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Player" && !transform.parent.gameObject.GetComponent<SpikeTenticleController>().phase2)
        {
            transform.parent.gameObject.GetComponent<Animator>().Play("Transition");
            transform.parent.gameObject.GetComponent<SpikeTenticleController>().phase2 = true;
        }
    }
}
