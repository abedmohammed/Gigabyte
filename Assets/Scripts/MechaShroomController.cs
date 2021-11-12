using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaShroomController : MonoBehaviour {

    private PlayerController player;
    private Camera cam;
    private Rigidbody2D rb;
    private Animator anim;

    public float moveSpeed;
    public float shieldDelayCD;
    private float shieldDelay;
    public bool shielded;

    void Start () {

        rb = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
        player = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();

        shieldDelay = shieldDelayCD;

    }

    void Update () {

        shieldDelay -= Time.deltaTime;

        if (shieldDelay > 0)
        {
            if (player.transform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                shielded = false;
            }
            else if (player.transform.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                shielded = false;
            }
        } else
        {
            shielded = true;
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }


        anim.SetBool("Shielded", shielded);

    }

    void resetCD()
    {

        shieldDelay = shieldDelayCD;

    }
}
