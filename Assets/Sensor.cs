using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour {

    public static bool inSensor;
    public bool sensed;
    public static int sensorCount;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("sensed", sensed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            sensorCount += 1;
            inSensor = true;
            sensed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            sensorCount -= 1;
            if (inSensor && sensorCount <= 0)
            {
                inSensor = false;
            }
            sensed = false;
        }
    }



}
