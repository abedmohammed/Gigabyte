using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildTurret : MonoBehaviour {

    private Camera cam;

    public float dropRateCD;
    private float dropRate;

    public GameObject shot;

    public bool withSpot;
    public Transform spot;
    public Transform spot2;
    public Transform spot3;

    public bool star;

    // Use this for initialization
    void Start () {


        cam = FindObjectOfType<Camera>();

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 currentPos = cam.WorldToViewportPoint(transform.position);

        dropRate -= Time.deltaTime;

        if (dropRate <= 0 && currentPos.x < 1f && currentPos.x > 0f && !withSpot)
        { 
            Instantiate(shot, transform.position, transform.rotation);
            
            dropRate = dropRateCD;
        }

        if(withSpot && Sensor.inSensor)
        {
            if (dropRate <= 0 && currentPos.x < 1f && currentPos.x > 0f)
            {
                if (star)
                {
                    Instantiate(shot, spot.transform.position, spot.transform.rotation);
                    Instantiate(shot, spot2.transform.position, spot.transform.rotation);
                    Instantiate(shot, spot3.transform.position, spot.transform.rotation);
                } else
                {
                    Instantiate(shot, spot.transform.position, spot.transform.rotation);
                }

                dropRate = dropRateCD;
            }
        }
        if (withSpot)
        {
            if (!Sensor.inSensor)
            {
                dropRate = dropRateCD;
            }
        }

    }
}
