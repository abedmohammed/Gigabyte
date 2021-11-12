using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotCollider : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    private PlayerController player;
    private EnemyHealthManager enemyHealthManager;

    public GameObject shotParticle;

    public GameObject hitNoise;

    public GameObject deflectNoise;


    public int damageToGive;

    public bool bigger;
    public bool passThrough;

    private Camera cam;


    void Start()
    {
        cam = FindObjectOfType<Camera>();
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (player.transform.localScale.x < 0 && bigger)
        {
            //speed = -speed;
            transform.localScale = new Vector3(-2, 2, 1);
        }

    }

    void FixedUpdate()
    {

        rb.velocity = new Vector2(speed, rb.velocity.y);

    }

    void Update()
    {
        Vector3 currentPos = cam.WorldToViewportPoint(transform.position);

        if (currentPos.x > 1f)
        {
            DestroyObject(gameObject);
        }
        else if (currentPos.x < 0f)
        {
            DestroyObject(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!passThrough)
        {
            if (other.tag == "Enemy" || other.tag == "Normal Block")
            {
                other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);

                Instantiate(hitNoise, transform.position, transform.rotation);

            }

            if (other.tag == "Enemy Shield" || other.tag == "EnemyPlus")
            {

                Instantiate(deflectNoise, transform.position, transform.rotation);

            }
            Instantiate(shotParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        //=========================================================================================
        if (passThrough)
        {
            List<GameObject> hitEnemies = new List<GameObject>();

            if (other.tag == "Enemy" || other.tag == "EnemyPlus")
            {
                other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
                Instantiate(hitNoise, transform.position, transform.rotation);
                Instantiate(shotParticle, transform.position, transform.rotation);
                enemyHealthManager = other.GetComponent<EnemyHealthManager>();
                if (enemyHealthManager.enemyHealth > 0)
                {
                    DestroyObject(gameObject);
                }
            } else
            {
                if (other.tag != "Enemy Projectile")
                {
                    if (other.tag == "Purple Block" && !bigger)
                    {
                        other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
                        Instantiate(hitNoise, transform.position, transform.rotation);
                        Instantiate(shotParticle, transform.position, transform.rotation);
                        enemyHealthManager = other.GetComponent<EnemyHealthManager>();
                        if (enemyHealthManager.enemyHealth > 0)
                        {
                            DestroyObject(gameObject);
                        }

                    }
                    else if (other.tag == "Pink Block" && bigger)
                    {
                        other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
                        Instantiate(hitNoise, transform.position, transform.rotation);
                        Instantiate(shotParticle, transform.position, transform.rotation);
                        enemyHealthManager = other.GetComponent<EnemyHealthManager>();
                        if (enemyHealthManager.enemyHealth > 0)
                        {
                            DestroyObject(gameObject);
                        }

                    }

                    else
                    {
                        Destroy(gameObject);
                        Instantiate(hitNoise, transform.position, transform.rotation);
                        Instantiate(shotParticle, transform.position, transform.rotation);
                    }
                }
            }

            if (other.tag == "Enemy Shield")
            {

                Instantiate(deflectNoise, transform.position, transform.rotation);
                Instantiate(shotParticle, transform.position, transform.rotation);

            }
           
        }
    }


}
