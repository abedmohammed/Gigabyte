using UnityEngine;
using System.Collections;

public class EnemyProjectileTrackEnemy : MonoBehaviour {

	public float speed;
    public float speedMultiplyer;

	public PlayerController player;
	
	public GameObject impactEffect;

	public int damageToGive;

	private Vector3 playerPos;

	private Quaternion _lookRotation;

    private Camera cam;

    public bool onScreen;

    public bool speedUp;


    // Use this for initialization
    void Start () {

        cam = FindObjectOfType<Camera>();

        player = FindObjectOfType<PlayerController>();


		playerPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);

		Vector3 difference = playerPos - transform.position;
		float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (speedUp)
        {
            speed = 1;
        }

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 currentPos = cam.WorldToViewportPoint(transform.position);

        if (speedUp)
        {
            speed += speed * speedMultiplyer;
        }

        transform.position += transform.right * speed * Time.deltaTime;

        if (speed >= 15)
        {
            speed = 15;
        }

        if (currentPos.x < 1f)
        {
            onScreen = true;
        }
        else if (currentPos.x > 0f)
        {
            onScreen = true;
        }


        if (currentPos.x > 1f && !onScreen)
        {
            DestroyObject(gameObject);
        }
        else if (currentPos.x < 0f && !onScreen)
        {
            DestroyObject(gameObject);
        }

    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			//for (var i = 0; i < coinsToGive.coinsToGive; i++)
			//{
			//Instantiate (coins, other.transform.position, other.transform.rotation);
			//}
			HealthManager.HurtPlayer(damageToGive);
		}
		
		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
		
	}

}
