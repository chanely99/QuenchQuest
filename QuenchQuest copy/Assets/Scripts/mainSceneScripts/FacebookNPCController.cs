using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class FacebookNPCController : MonoBehaviour {
	public float timeToRead = 4f; 
	public bool startCountdown = false; 
	public GameObject speechBubble; 
	// Use this for initialization
	void Start () {
		speechBubble.SetActive (false);
	}
	void OnTriggerEnter2D(){
		if (!MainSceneManager.beatFacebook) {
			speechBubble.SetActive (true); 
			startCountdown = true; 
		}
	}
	// Update is called once per frame
	void Update () {
		if (startCountdown) {
			timeToRead -= Time.deltaTime;
			if (timeToRead <= 0) {
				SceneManager.LoadScene("facebookScene");
				Debug.Log ("Loaded facebookScene");
			}

		}
	}
}
