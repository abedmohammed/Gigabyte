using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeepVolume : MonoBehaviour {

    public Slider volumeBar;
    public GameObject options;

    // Use this for initialization
    void Start () {

        volumeBar = GetComponent<Slider>();
        volumeBar.value = PlayerPrefs.GetFloat("Volume");
    }
	
	// Update is called once per frame
	void Update () {
        if (FindObjectOfType<MainMenu>().isPaused)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }

            if(SceneManager.GetActiveScene().buildIndex != 0)
            {
                transform.parent = options.transform;
            }
            

        }
        else if (!FindObjectOfType<MainMenu>().isPaused)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

        }
    }
}
