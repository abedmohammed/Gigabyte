using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvis : MonoBehaviour {

	void Start () {
        gameObject.GetComponent<Renderer>().enabled = false;
    }
	
}
