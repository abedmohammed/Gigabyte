using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperController : MonoBehaviour {

    private Rigidbody2D rb;

    public float jumpForce;
    public float CD;
    private float jumpRate;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        jumpRate = CD;
    }
	
	// Update is called once per frame
	void Update () {

        jumpRate -= Time.deltaTime;

        if(jumpRate <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            jumpRate = CD;
        }

        if(GetComponent<EnemyHealthManager>().enemyHealth <= 0)
        {
            rb.velocity = new Vector2(0, 0);
        }

	}
}
