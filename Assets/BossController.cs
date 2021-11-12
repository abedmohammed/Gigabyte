using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour {

    private EnemyHealthManager enemyHealth;
    private Animator anim;

    public float maxEnemyHealth;

    public enum Phase {Phase1, Phase2, Phase3 }

    public Phase phase;

    public float percentage;

    public float Phase1CD;
    public float Phase1Timer;

    public float Phase2CD;
    public float Phase2Timer;


    public bool phase1;
    public bool phase2;
    public bool phase3;

    public bool check;

    public GameObject laser;
    public GameObject Rocket;
    public GameObject beam;
    public GameObject shot;
    public Transform shootPosition;
    public PlayerController player;

    private int indexNumber;

    // Use this for initialization
    void Start () {

        player = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealthManager>();

        phase = Phase.Phase1;

        maxEnemyHealth = enemyHealth.enemyHealth;

        Phase1Timer = Phase1CD;

        indexNumber = SceneManager.GetActiveScene().buildIndex;
        indexNumber += 1;
    }
	
	// Update is called once per frame
	void Update () {

        percentage = enemyHealth.enemyHealth / maxEnemyHealth * 100;

        if(percentage >= 63)
        {
            phase = Phase.Phase1;
        }

        if (percentage >= 33 && percentage < 63)
        {
            phase = Phase.Phase2;
        }

        if (percentage >= 0 && percentage < 33)
        {
            phase = Phase.Phase3;
        }

        anim.SetBool("Phase1", phase1);
        anim.SetBool("Phase2", phase2);
        anim.SetBool("Phase3", phase3);

        if (phase == Phase.Phase1)
        {
            Phase1Timer -= Time.deltaTime;
            if (Phase1Timer <= 0)
            {
                phase1 = true;
            } 

        }

        if (phase == Phase.Phase2)
        {
            phase2 = true;

        } else
        {
            phase2 = false;
        }

        if (phase == Phase.Phase3)
        {
            phase3 = true;
            Phase2Timer -= Time.deltaTime;
            if(Phase2Timer <= 0 && check == true)
            {
                Instantiate(beam, new Vector2(player.transform.position.x, player.transform.position.y - 10), Quaternion.Euler(0, 0, -90));
                StartCoroutine("Phase3");
                Phase2Timer = Phase2CD;
            }
        }

        if (enemyHealth.enemyHealth <= 0)
        {
            StartCoroutine("win");
        }

    }

    public IEnumerator Phase3()
    {
        Instantiate(shot, shootPosition.transform.position, shootPosition.transform.rotation);

        yield return new WaitForSeconds(0.1f);
        Instantiate(shot, shootPosition.transform.position, shootPosition.transform.rotation);

        yield return new WaitForSeconds(0.1f);
        Instantiate(shot, shootPosition.transform.position, shootPosition.transform.rotation);

        yield return new WaitForSeconds(0.1f);
        Instantiate(shot, shootPosition.transform.position, shootPosition.transform.rotation);

        yield return new WaitForSeconds(0.1f);
    }

    public IEnumerator win()
    {
        yield return new WaitForSeconds(5f);
        float fadeTime = GameObject.Find("Level Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(indexNumber);
    }

    void shootLaser()
    {
        Instantiate(laser, shootPosition.transform.position, shootPosition.transform.rotation);
    }

    void shootRocket()
    {
        Instantiate(Rocket, shootPosition.transform.position, shootPosition.transform.rotation);
    }


    void resetTimer()
    {
        phase1 = false;
        Phase1Timer = Phase1CD;
        phase2 = false;
    }

    void Check()
    {
        check = true;
    }
    void Uncheck()
    {
        check = false;
    }


}
