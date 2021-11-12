using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDropper : MonoBehaviour {

    private Rigidbody2D rb;
    private Camera cam;

    public float moveSpeed;
    public bool moveRight;
    private bool facingRight;

    public float magnitude;
    public float frequency;

    Vector3 pos;

    public float dropRateCD;
    private float dropRate;

    public GameObject mine;

    // Use this for initialization
    void Start () {

        pos = transform.position;

        rb = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 currentPos = cam.WorldToViewportPoint(transform.position);

        if (currentPos.x >= 0.9f && facingRight)
        {
            moveRight = !moveRight;
            facingRight = false;
        } else if (currentPos.x <= 0.1f && !facingRight)
        {
            moveRight = !moveRight;
            facingRight = true;
        }

        if (currentPos.y > 1)
        {
            DestroyObject(gameObject);
        }

        if (currentPos.y < 0)
        {
            DestroyObject(gameObject);
        }

        pos = transform.up * Mathf.Sin(Time.time * frequency) * magnitude;


        if (moveRight)
        {
            rb.velocity = new Vector2(moveSpeed, pos.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, pos.y);
        }

        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        dropRate -= Time.deltaTime;

        if(dropRate <= 0)
        {
            Instantiate(mine, transform.position, transform.rotation);
            dropRate = dropRateCD;
        }

    }
}
