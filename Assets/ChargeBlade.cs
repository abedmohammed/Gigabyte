using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBlade : MonoBehaviour {

    private Rigidbody2D rb;
    private Camera cam;

    public float moveSpeed;
    public float moveSpeedMultiplyer;

    // Use this for initialization
    void Start () {

        cam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 currentPos = cam.WorldToViewportPoint(transform.position);



        if (currentPos.x < -0.2f)
        {
            DestroyObject(gameObject);
        }


        if (currentPos.x < 1f)
        {
            moveSpeed += 1 * moveSpeedMultiplyer;

            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

    }
}
