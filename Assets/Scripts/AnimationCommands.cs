using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCommands : MonoBehaviour {

    public GameObject object1;
    public CameraShake cameraShake;

    public float time = 0.1f;
    public float magnitude = 0.1f;

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void spawnObject()
    {
        Instantiate(object1, transform.position, transform.rotation);
    }

    public void spawnObject2(GameObject object2)
    {
        Instantiate(object2, transform.position, transform.rotation);
    }

    public GameObject[] Objects;

    public void SpawnList()
    {
        foreach (var spawnObject in Objects)
        {
            GameObject instanceObject = Instantiate(spawnObject, transform.position, transform.rotation) as GameObject;
        }
    }

    public void shakeScreen()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        StartCoroutine(cameraShake.Shake(time, magnitude));
    }

}
