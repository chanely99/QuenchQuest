using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class TextBoxManager : MonoBehaviour {

	private int gameStatus; 
	private bool leftSideBad; 
	private bool waitingToSwitch = false;

	const int isWaitingForInput = 0;
	const int needToAskQuestion = 1; 
	const int isNotWaitingForInput = 2; 

	private bool lostGame; 
	private float timeToRead = 1f; 

	public GameObject textBox; 
	public Text theText;

	public Text Option1;
	public Text Option2; 
	public Text numStrikesText; 

	public TextAsset BadQuestionsTextFile; 
	public TextAsset GoodQuestionsTextFile; 
	public TextAsset BadAnswersTextFile; 
	public TextAsset GoodAnswersTextFile; 
	public string[] BadQuestionstextLines; 
	public string[] BadAnswerstextLines; 
	public string[] GoodQuestionstextLines; 
	public string[] GoodAnswerstextLines; 

	public int currentQuestion; 

	private int numStrikes;


	// Use this for initialization
	void Start () {
		Debug.Log ("Game start");
		numStrikes = 0; 
		BadQuestionstextLines = (BadQuestionsTextFile.text.Split ('\n'));
		BadAnswerstextLines = (BadAnswersTextFile.text.Split ('\n'));
		GoodQuestionstextLines = (GoodQuestionsTextFile.text.Split ('\n'));
		GoodAnswerstextLines = (GoodAnswersTextFile.text.Split ('\n'));
		gameStatus = needToAskQuestion;
		lostGame = false; 
		currentQuestion = 0; 
	}

	void newQuestion(int i){
		timeToRead = 3f; 
		theText.text = "What question do you have?";
		if (Random.Range (0, 10) > 5) {
			Option1.text = BadQuestionstextLines [i];
			Option2.text = GoodQuestionstextLines [i];
			leftSideBad = true; 
			gameStatus = isWaitingForInput; 

		} else {
			Option1.text = GoodQuestionstextLines [i];
			Option2.text = BadQuestionstextLines [i];
			leftSideBad = false; 
			gameStatus = isWaitingForInput; 

		}
	}

	void answerQuestion(bool good){
		if (good) {
			theText.text = GoodAnswerstextLines [currentQuestion];
		} else {
			numStrikes++; 
			theText.text = BadAnswerstextLines [currentQuestion];
		}
	}

	void Update(){
		numStrikesText.text = "Strikes: " + numStrikes.ToString(); 
		if (numStrikes == 3) {
			gameStatus = isNotWaitingForInput;
			lostGame = true; 
		}

		if (gameStatus == needToAskQuestion) {
			newQuestion (currentQuestion);
			gameStatus = isWaitingForInput; 
		} 
		else if (gameStatus == isWaitingForInput) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if (leftSideBad) {
					answerQuestion (false);
					gameStatus = isNotWaitingForInput; 
				} else {
					answerQuestion (true);
					gameStatus = isNotWaitingForInput; 
				}
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if (leftSideBad) {
					answerQuestion (true);
					gameStatus = isNotWaitingForInput; 
				} else {
					answerQuestion (false);
					gameStatus = isNotWaitingForInput;  
				}
			}
		}
		else if(gameStatus == isNotWaitingForInput)
		{
			if (timeToRead > 0) {
				timeToRead -= Time.deltaTime;
			} 
			else {
				currentQuestion++;
				if (lostGame) {
					MainSceneManager.beatFacebook = false; 
					Option1.text = "";
					Option2.text = "";
					theText.text = "I'm sorry, your questions suck";
					//wait 2 seconds
					timeToRead = 2f; 
					waitingToSwitch = true;
					Debug.Log ("Lost Game :(");
				} else if (currentQuestion == 5) {
					MainSceneManager.beatFacebook = true; 
					Option1.text = "";
					Option2.text = "";
					theText.text = "It was great talking to you, I hope to see you later!";
					//wait 2 seconds
					timeToRead = 2f; 
					waitingToSwitch = true; 
					Debug.Log ("Won Game :)");

				} else if (waitingToSwitch) {
					if (lostGame)
						SceneManager.LoadScene ("gameOverScene");
					SceneManager.LoadScene ("mainScene");
				}
				else{
					newQuestion (currentQuestion);
				}
			}
		}
	} 
}