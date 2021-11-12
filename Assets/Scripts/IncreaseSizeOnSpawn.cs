using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSizeOnSpawn : MonoBehaviour {

    private PlayerController player;

    public float endSizeX;
    public float endSizeY;

    public float negativeEndSizeX;
    public float negativeEndSizeY;

    public float FadeTime;

    private float currentSizeX;
    private float currentSizeY;

    private bool facingLeft;

    void Start () {

        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0)

        {

            facingLeft = true;

        }

    }
	
	// Update is called once per frame
	void Update () {

        if (transform.localScale.x < endSizeX && transform.localScale.y < endSizeY && !facingLeft)
        {

            currentSizeX = transform.localScale.x;
            currentSizeX += endSizeX * Time.deltaTime / FadeTime;

            currentSizeY = transform.localScale.y;
            currentSizeY += endSizeY * Time.deltaTime / FadeTime;

        }


        if (transform.localScale.x < endSizeX && transform.localScale.y < endSizeY && facingLeft)
        {

            currentSizeX = transform.localScale.x;
            currentSizeX += negativeEndSizeX * Time.deltaTime / FadeTime;

            currentSizeY = transform.localScale.y;
            currentSizeY += endSizeY * Time.deltaTime / FadeTime;

        }

        transform.localScale = new Vector3(currentSizeX, currentSizeY, transform.localScale.z);

    }
}
