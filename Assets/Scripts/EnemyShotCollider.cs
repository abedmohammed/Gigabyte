using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotCollider : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public bool right;
    public bool up;

    public int damageToGive;
    public GameObject impactEffect;

    private Camera cam;

    public bool onScreen;


    // Use this for initialization
    void Start () {

        cam = FindObjectOfType<Camera>();

        rb = GetComponent<Rigidbody2D>();
        if (!right)
        {
            speed = -speed;
            transform.localScale *= -1f;
        }
        if (up)
        {
            rb.rotation = 90;
        }


    }
	
	// Update is called once per frame
	void Update () {

        Vector3 currentPos = cam.WorldToViewportPoint(transform.position);

        if (currentPos.x < 1f)
        {
            onScreen = true;
        }
        else if (currentPos.x > 0f)
        {
            onScreen = true;
        }


        if (currentPos.x > 1f && !onScreen)
        {
            DestroyObject(gameObject);
        }
        else if (currentPos.x < 0f && !onScreen)
        {
            DestroyObject(gameObject);
        }

        if (!up)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else if(up)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
