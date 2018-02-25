using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class MainSceneManager : MonoBehaviour {

	public static bool beatFacebook = false; 
	public static bool beatPacMini = false; 
	public static bool stayedAwake = false; 

	public GameObject facebookActivate; 
	public GameObject pacManActivate; 


	public GameObject background1;
	public GameObject background2; 
	public GameObject background3; 
	public float timeToRead = 3f; 
	// Use this for initialization
	void Start () {
		background1.SetActive (true); 
	}
	
	// Update is called once per frame
	void Update () {
		if (beatFacebook & !beatPacMini) {
			facebookActivate.SetActive (false);
			background1.SetActive (false);
			background2.SetActive (true);
			pacManActivate.SetActive (true);

		}

		if (beatFacebook & beatPacMini) {
			pacManActivate.SetActive (false); 
			facebookActivate.SetActive (false); 
			timeToRead -= Time.deltaTime; 
			if (timeToRead <= 0)
				SceneManager.LoadScene ("winScene");
		}
	}
}
