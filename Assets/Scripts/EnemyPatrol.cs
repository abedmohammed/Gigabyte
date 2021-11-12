using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool isAtWall;
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;

    public bool usesSensor;

    private PlayerController player;

    private Camera cam;

    // Use this for initialization
    void Start () {

        cam = FindObjectOfType<Camera>();

        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 currentPos = cam.WorldToViewportPoint(transform.position);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        isAtWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        if(!isGrounded || isAtWall)
        {
            moveRight = !moveRight;
        }

        if (!usesSensor)
        {
            if (moveRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
        }
        else
        {
            if (Sensor.inSensor && currentPos.x < 1f && currentPos.x > 0f)
            {
                if (player.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                }
                else if (player.transform.position.x < transform.position.x)
                {
                    rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                }
            }
        }

        if (!usesSensor)
        {
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        } else
        {
            if (Sensor.inSensor && currentPos.x < 1f && currentPos.x > 0f)
            {
                if (rb.velocity.x > 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (rb.velocity.x < 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }

	}
}
