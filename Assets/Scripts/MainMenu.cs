using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public string startLevel;

    public string mainMenuu;
	public string levelSelect;

    public string Tutorial;

    public string Level1_1;

    public string Level1_2;

    public string Level1_3;

    public string Level1_4;

    public string Level2_1;

    public string Level2_2;

    public string Boss;

    public GameObject settingsMenu;

    private SceneTransition transition;

    public bool isPaused;

    //public int playerHealth;


    void Start()
    {
        transition = FindObjectOfType<SceneTransition>();
    }

    void Update()
    {
        if (isPaused)
        {
            settingsMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            settingsMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
        }
    }

    public void NewGame()
    {
        StartCoroutine("NewGameCo");
    }

    public void Tut()
    {
        StartCoroutine("TutorialCo");
    }

    public void LevelSelect()
    {
        StartCoroutine("LevelSelectCo");
    }

    public void LV1_1()
    {
        StartCoroutine("Level1_1Co");
    }
    public void LV1_2()
    {
        StartCoroutine("Level1_2Co");
    }
    public void LV1_3()
    {
        StartCoroutine("Level1_3Co");
    }
    public void LV1_4()
    {
        StartCoroutine("Level1_4Co");
    }
    public void LV2_1()
    {
        StartCoroutine("Level2_1Co");
    }
    public void LV2_2()
    {
        StartCoroutine("Level2_2Co");
    }
    public void boss()
    {
        StartCoroutine("BossCo");
    }


    public IEnumerator NewGameCo()
	{
        yield return new WaitForSeconds(0.5f);
        transition.Transition();
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt("enemiesKilled", 0);
        PlayerPrefs.SetInt("deaths", 0);
        Application.LoadLevel (startLevel);

    }
	
	public IEnumerator LevelSelectCo()
	{
        yield return new WaitForSeconds(0.5f);
        transition.Transition();
        yield return new WaitForSeconds(2f);
        Application.LoadLevel (levelSelect);
	}

    public void Settings()
    {
        isPaused = true;
    }

    public void QuitGame()
	{
        isPaused = false;
        Application.Quit();
    }

    public void title()
    {
        isPaused = false;
        StartCoroutine("titleCo");
    }

    public IEnumerator titleCo()
    {
        //yield return new WaitForSeconds(0.5f);
        if(!transition == null)
        {
            transition.Transition();
        }
        yield return new WaitForSeconds(0.01f);
        Application.LoadLevel(mainMenuu);

    }

    public IEnumerator TutorialCo()
    {
        yield return new WaitForSeconds(0.5f);
        transition.Transition();
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(Tutorial);
    }

    public IEnumerator Level1_1Co()
    {
        yield return new WaitForSeconds(0.5f);
        transition.Transition();
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(Level1_1);
    }

    public IEnumerator Level1_2Co()
    {
        yield return new WaitForSeconds(0.5f);
        transition.Transition();
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(Level1_2);
    }

    public IEnumerator Level1_3Co()
    {
        yield return new WaitForSeconds(0.5f);
        transition.Transition();
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(Level1_3);
    }
    public IEnumerator Level1_4Co()
    {
        yield return new WaitForSeconds(0.5f);
        transition.Transition();
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(Level1_4);
    }

    public IEnumerator Level2_1Co()
    {
        yield return new WaitForSeconds(0.5f);
        transition.Transition();
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(Level2_1);
    }

    public IEnumerator Level2_2Co()
    {
        yield return new WaitForSeconds(0.5f);
        transition.Transition();
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(Level2_2);
    }

    public IEnumerator BossCo()
    {
        yield return new WaitForSeconds(0.5f);
        transition.Transition();
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(Boss);
    }
}
