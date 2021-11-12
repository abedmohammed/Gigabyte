using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Signs : MonoBehaviour {

	public string signText;
	private SignCaller sCaller;


	void Start () 
	{	

		sCaller = FindObjectOfType<SignCaller>();

	}
	
	void Update () 
	{
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.name == "Player") {

			sCaller.ShowSign (signText);

		} 


	}

	void OnTriggerExit2D(Collider2D other)
	{
		
		if (other.gameObject.name == "Player") {
			
			sCaller.signBox.SetActive(false);
			
		} 
		
		
	}

}
