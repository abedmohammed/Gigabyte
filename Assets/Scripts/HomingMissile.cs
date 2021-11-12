using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {

    private Transform target;
    private Rigidbody2D rb;

    public float speed;
    public float rotateSpeed;

    public float timer;

    // Use this for initialization
    void Start () {

        target = FindObjectOfType<PlayerController>().transform;
        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        timer -= Time.deltaTime;

        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, -transform.right).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = -transform.right * speed;

        if(timer <= 0)
        {
            GetComponent<EnemyHealthManager>().giveDamage(1);
        }

	}
}
