using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealth;

    private Animator anim;

    private Rigidbody2D rb;

    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    private bool added;

    // Use this for initialization
    void Start () {

        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
		
        if(enemyHealth <= 0)
        {
            anim.Play("DeathAnimation");
            if (!added)
            {
                PlayerPrefs.SetInt("enemiesKilled", PlayerPrefs.GetInt("enemiesKilled") + 1);
                added = true;
            }
        }

	}

    public void giveDamage(int damageToGive)
    {
        StartCoroutine("ChangeEnemyColour");
        enemyHealth -= damageToGive;
    }

    public IEnumerator ChangeEnemyColour()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
        yield return new WaitForSeconds(.1f);
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
    }
}
