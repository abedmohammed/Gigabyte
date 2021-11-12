using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillDopController : MonoBehaviour {

    private PlayerController player;
    private Camera cam;
    private Rigidbody2D rb;

    public float moveSpeed;
    private float heightSpeed;
    public float multiplyer;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
        player = FindObjectOfType<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 currentPos = cam.WorldToViewportPoint(transform.position);
        rb.velocity = new Vector2(moveSpeed, -heightSpeed * multiplyer);

        if (currentPos.x < -0.2f)
        {
            DestroyObject(gameObject);
        }


        if(currentPos.x < 1f)
        {
            heightSpeed = transform.position.y - player.transform.position.y;
        }

    }
}
