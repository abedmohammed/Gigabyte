using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSide : MonoBehaviour {

    private PlayerController player;

    // Use this for initialization
    void Start () {

        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
