using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxShooterController : MonoBehaviour {

    public Transform spawnPointRight;
    public Transform spawnPointLeft;
    public Transform spawnPointUp;

    public GameObject shotRight;
    public GameObject shotLeft;
    public GameObject shotUp;

    public GameObject shootParticleRight;
    public GameObject shootParticleLeft;

    public GameObject bomb;

    private Camera cam;

    public float shotDelayCD;
    private float shotDelay;

    public bool phase2;
    public bool phase22;

    public GameObject object1;
    public GameObject object2;

    public GameObject[] Objects;

    // Use this for initialization
    void Start () {

        cam = FindObjectOfType<Camera>();

        shotDelay = shotDelayCD;
        phase2 = false;
    }
	
	// Update is called once per frame
	void Update () {

        shotDelay -= Time.deltaTime;

        Vector3 currentPos = cam.WorldToViewportPoint(transform.position);

        if(GetComponent<EnemyHealthManager>().enemyHealth <= 6 && !phase22)
        {
            GetComponent<Animator>().Play("Transition");

            foreach (var spawnObject in Objects)
            {
                GameObject instanceObject = Instantiate(spawnObject, transform.position, transform.rotation) as GameObject;
            }
            phase22 = true;
        }

        if (!phase2)
        {
            if (shotDelay <= 0 && currentPos.x < 1f && currentPos.x > 0f)
            {
                Instantiate(shootParticleRight, spawnPointRight.position, spawnPointRight.rotation);
                Instantiate(shootParticleLeft, spawnPointLeft.position, spawnPointRight.rotation);
                Instantiate(shootParticleRight, spawnPointUp.position, spawnPointUp.rotation);

                Instantiate(shotRight, spawnPointRight.position, spawnPointRight.rotation);
                Instantiate(shotLeft, spawnPointLeft.position, spawnPointLeft.rotation);
                Instantiate(shotUp, spawnPointUp.position, spawnPointUp.rotation);

                shotDelay = shotDelayCD;
            }
        } else
        {
            if (shotDelay <= 0 && currentPos.x < 1f && currentPos.x > 0f)
            {

                Instantiate(bomb, spawnPointUp.position, spawnPointUp.rotation);
                Instantiate(shootParticleRight, spawnPointUp.position, spawnPointUp.rotation);
                Instantiate(bomb, spawnPointUp.position, spawnPointUp.rotation);
                Instantiate(shootParticleRight, spawnPointUp.position, spawnPointUp.rotation);
                Instantiate(bomb, spawnPointUp.position, spawnPointUp.rotation);
                Instantiate(shootParticleRight, spawnPointUp.position, spawnPointUp.rotation);

                shotDelay = shotDelayCD;
            }
        }

        if (currentPos.x > 1 || currentPos.x < 0)
        {
            shotDelay = shotDelayCD;
        }

        GetComponent<Animator>().SetBool("Phase2", phase2);

    }

    public void switchMode()
    {
        phase2 = true;
    }
}
