using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {


    public static int playerHealth;

    public int maxPlayerHealth;

    //Text text;
    public Slider healthBar;

    private LevelManager levelManager;

    public bool isDead;

    
    // Use this for initialization
	void Start () {

        //text = GetComponent<Text>();
        healthBar = GetComponent<Slider>();

        playerHealth = maxPlayerHealth;

        levelManager = FindObjectOfType<LevelManager>();

        isDead = false;

	}
	
	// Update is called once per frame
	void Update () {

        if(playerHealth <= 0 && !isDead)
        {
            levelManager.RespawnPlayer();
            isDead = true;
        }

        //text.text = "" + playerHealth;
        healthBar.value = maxPlayerHealth - playerHealth;
	}

    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
    }
}
