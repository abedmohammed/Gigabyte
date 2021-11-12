using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSensed : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Animator>().SetBool("sensed", Sensor.inSensor);

		
	}
}
