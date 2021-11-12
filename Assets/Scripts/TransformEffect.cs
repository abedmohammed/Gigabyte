using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEffect : MonoBehaviour {

    public GameObject chargeEffect;
    public Transform chargeSpot;
    private GameObject chargingEffect;

    public float transformTime;

	// Use this for initialization
	void Start () {

        chargeSpot = transform.parent;

	}
	
	// Update is called once per frame
	void Update () {

        transformTime -= Time.deltaTime;
        if (transformTime < -1)
        {
            chargingEffect = Instantiate(chargeEffect, chargeSpot.position, chargeSpot.rotation);
            chargingEffect.transform.parent = chargeSpot.transform;
            DestroyObject(gameObject);
        }
	}
}
