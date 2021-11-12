using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SignCaller : MonoBehaviour {

	public GameObject signBox;
	public Text signText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}	

	public void ShowSign(string Text)
	{
		signBox.SetActive (true);
		signText.text = Text;
	}
}
