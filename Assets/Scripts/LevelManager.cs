using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private PlayerController player;
    private SceneTransition transition;
    private CameraShake cameraShake;
    public bool isDead;

    public float time;
    public float magnitude;

    private float gravityStore;

    public GameObject deathEffect;

    void Awake () {
        player = FindObjectOfType<PlayerController>();
        transition = FindObjectOfType<SceneTransition>();
        cameraShake = FindObjectOfType<CameraShake>();

    }

    public void RespawnPlayer()
    {

        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        isDead = true;
        FindObjectOfType<CameraFollow>().stopFollow = true;
        StartCoroutine(cameraShake.Shake(time, magnitude));
        SpawnList();
        Instantiate(deathEffect, player.transform.position, transform.rotation);
        player.enabled = false;
        player.GetComponent<Collider2D>().enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        gravityStore = player.rb.gravityScale;
        player.rb.gravityScale = 0f;
        player.rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        transition.Transition();
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetInt("deaths", PlayerPrefs.GetInt("deaths") + 1);
        Debug.Log("Respawn Requested");
        Application.LoadLevel(SceneManager.GetActiveScene().name);

    }

    public GameObject[] MyObjects;

    public void SpawnList()
    {
        foreach (var spawnObject in MyObjects)
        {
            GameObject instanceObject = Instantiate(spawnObject, player.transform.position, transform.rotation) as GameObject;
        }
    }

}
