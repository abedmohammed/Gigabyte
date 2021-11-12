using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseSettings : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private MainMenu mainMenu;
    public bool over;

	// Use this for initialization
	void Start () {

        mainMenu = FindObjectOfType<MainMenu>();

	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonDown(0) && !over && mainMenu.isPaused)
        {
            mainMenu.isPaused = false;
        }

	}

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        over = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        over = false;
    }


}
