using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTenticleController : MonoBehaviour {

    public bool phase2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Animator>().SetBool("Phase 2", phase2);

        if(GetComponent<EnemyHealthManager>().enemyHealth <= 1 && !phase2)
        {
            GetComponent<Animator>().Play("Transition");
            phase2 = true;
        }

    }


}
