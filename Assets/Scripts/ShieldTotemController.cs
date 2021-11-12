using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTotemController : MonoBehaviour {

    public GameObject shot;
    public GameObject shot2;
    public GameObject shotParticle;
    public GameObject shotParticle2;
    public Transform shootPoint;
    public Transform shootPoint2;
    public Transform shootPoint3;
    public Transform shootPoint4;
    public float shotDelayCD;
    private float shotDelay;
    public bool shooted;

    private Animator anim;

    private Camera cam;

    void Start () {

        cam = FindObjectOfType<Camera>();

        anim = GetComponent<Animator>();
        shotDelay = shotDelayCD;
	}
	
	// Update is called once per frame
	void Update () {

        shotDelay -= Time.deltaTime;

        Vector3 currentPos = cam.WorldToViewportPoint(transform.position);

        if (shotDelay < 0 && currentPos.x < 1f && currentPos.x > 0f)
        {
            shooted = true;
        } else
        {
            shooted = false;
        }

        if (currentPos.x > 1 || currentPos.x < 0)
        {
            shotDelay = shotDelayCD;
        }

        anim.SetBool("Shoot", shooted);
		
	}
    
    void shoot()
    {
        Instantiate(shotParticle, shootPoint2.position, shootPoint2.rotation);
        Instantiate(shotParticle2, shootPoint2.position, shootPoint2.rotation);
        Instantiate(shot, shootPoint.position, shootPoint.rotation);
        Instantiate(shot2, shootPoint.position, shootPoint.rotation);

        Instantiate(shotParticle, shootPoint4.position, shootPoint2.rotation);
        Instantiate(shotParticle2, shootPoint4.position, shootPoint2.rotation);
        Instantiate(shot, shootPoint3.position, shootPoint.rotation);
        Instantiate(shot2, shootPoint3.position, shootPoint.rotation);
    }

    void charge()
    {
        shooted = false;
        shotDelay = shotDelayCD;
    }

}
