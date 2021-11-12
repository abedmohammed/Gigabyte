using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserBeam : MonoBehaviour {

    public PlayerController player;

    private Vector3 playerPos;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        Vector3 difference = playerPos - transform.position;

        float rotationZ = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 180;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
