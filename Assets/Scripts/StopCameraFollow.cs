using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCameraFollow : MonoBehaviour {

    private CameraFollow cameraFollow;

	// Use this for initialization
	void Start () {

        cameraFollow = FindObjectOfType<CameraFollow>();

	}
	
	// Update is called once per frame
	void Update () {
		


	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player" && !FindObjectOfType<LevelManager>().isDead)
        {
            cameraFollow.stopFollow = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player" && !FindObjectOfType<LevelManager>().isDead)
        {
            cameraFollow.stopFollow = false;
        }
    }

}
