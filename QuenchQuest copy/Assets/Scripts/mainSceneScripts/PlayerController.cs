using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour {
	public float speed = 5f; 
	public float waitToSpeak = 2; 
	private bool triggeredFacebook = false; 
	private bool triggeredNapRoom = false; 
	Rigidbody2D rb; 
	public GameObject text; 
	public GameObject text2; 
	public GameObject text3; 
	void Start () {
		rb = GetComponent<Rigidbody2D> (); 
		text.SetActive (false); 
		if (MainSceneManager.beatFacebook) {
			gameObject.transform.position = new Vector3 (1, gameObject.transform.position.y, gameObject.transform.position.z);
			text.SetActive (false); 
		}
		if (MainSceneManager.beatPacMini) {
			text2.SetActive(false); 
			waitToSpeak = 2; 
		}
	}

	// Update is called once per frame
	void Update () {
		
		float x = Input.GetAxisRaw ("Horizontal");
		transform.rotation = Quaternion.Euler (0, 0, 0);
		rb.velocity = new Vector2 (x, 0).normalized * speed; 
		if (triggeredFacebook) {
			if (waitToSpeak <= 0)
				text.SetActive (true);
			else
				waitToSpeak -= Time.deltaTime;
		} else if (triggeredNapRoom) {
			if (waitToSpeak <= 0)
				SceneManager.LoadScene ("pacMini");
			else {
				text2.SetActive (true);
				waitToSpeak -= Time.deltaTime;

			}
		} else if (MainSceneManager.beatPacMini && MainSceneManager.beatFacebook) {
			text3.SetActive (true); 
			if (waitToSpeak <= 0)
				SceneManager.LoadScene ("winScene");
			else {
				waitToSpeak -= Time.deltaTime;
			}
		}

	}
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "facebookPerson" && !MainSceneManager.beatFacebook) {
			triggeredFacebook = true; 
		}
		if (other.tag == "naproomdoor") {
			triggeredNapRoom = true; 
			text2.SetActive (true); 
			waitToSpeak = 3f;

		}
	}
}
