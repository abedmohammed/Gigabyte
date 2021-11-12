using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScores : MonoBehaviour {

	// Use this for initialization
	void Start () {
        KongregateAPI kongregate = KongregateAPI.Create();
        kongregate.SubmitStats("Enemies-Killed", PlayerPrefs.GetInt("enemiesKilled"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
