using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSkullController : MonoBehaviour {

    private Animator anim;

    public float shootDelayCD;
    private float shootDelay;

    public GameObject laser;
    public GameObject laserPosition;

    private bool shooting;

    private Camera cam;

    public GameObject enemy;
    public Transform spawnPoint;
    public GameObject rocket;
    public Transform rocketSpawnPoint;
    private float SpawnDelay;
    public float SpawnDelayCD;

    // Use this for initialization
    void Start() {

        cam = FindObjectOfType<Camera>();

        shootDelay = shootDelayCD;
        SpawnDelay = SpawnDelayCD;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {

        Vector3 currentPos = cam.WorldToViewportPoint(transform.position);

        if (currentPos.x < 1.1f && currentPos.x > -0.1f)
        {
            shootDelay -= Time.deltaTime;
            SpawnDelay -= Time.deltaTime;

            if (shootDelay <= 0)
            {
                shooting = true;
            } else
            {
                shooting = false;
            }

            if(SpawnDelay <= 0)
            {
                Instantiate(rocket, rocketSpawnPoint.position, rocketSpawnPoint.rotation);
                SpawnDelay = SpawnDelayCD;

            }

        }

        anim.SetBool("Shooting", shooting);

    }

    void ShootLaser()
    {
        Instantiate(laser, laserPosition.transform.position, laserPosition.transform.rotation);
    }

    void resetCD()
    {
        shootDelay = shootDelayCD;
    }
}
