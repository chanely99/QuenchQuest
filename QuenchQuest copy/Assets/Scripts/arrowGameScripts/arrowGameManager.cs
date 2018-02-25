using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class arrowGameManager : MonoBehaviour {
	public Text scoreText;
	public Text timeText; 

	private float timeRemaining = 30f; 
	public int score; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score; 
		timeRemaining = timeRemaining - Time.deltaTime; 
		timeText.text = "Time: " + timeRemaining; 
	}
}
