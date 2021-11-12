using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public Transform spawnPoint;

    public bool seen;

    private Camera cam;

    void Start()
    {

        cam = FindObjectOfType<Camera>();

    }


    public void Update()
    {

        Vector3 viewPosition = cam.WorldToViewportPoint(transform.position);

        if (viewPosition.x >= 1.05f && viewPosition.x <= 1.10f && !seen)
        {
            seen = true;
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }

    }


    //void OnBecameVisible()
    //{

    //seen = true;
    //Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);

    //}

}
