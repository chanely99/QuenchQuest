using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class playerMove : MonoBehaviour {

	public float speed = 0.2f;
	Vector2 dest = Vector2.zero;
	public int clocksToFind = 9;

	// Use this for initialization
	void Start () {	
		dest = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);
		//if ((Vector2)transform.position == dest) {
		if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up)) {
			dest = (Vector2)transform.position + Vector2.up;
		}
		if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right)) {
			dest = (Vector2)transform.position + Vector2.right;
		}
		if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up)) {
			dest = (Vector2)transform.position - Vector2.up;
		}
		if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right)) {
			dest = (Vector2)transform.position - Vector2.right;
		}
		//}
		clocksToFind = GameObject.FindGameObjectsWithTag("Clock").Length;
		if (clocksToFind == 0) {
			SceneManager.LoadScene ("mainScene");
			MainSceneManager.beatPacMini = true; 
			Debug.Log("load new scene");
			//load next scene
		}
	}

	bool valid(Vector2 dir) {
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos+dir, pos);
		return (hit.collider == GetComponent<Collider2D>());
	}

}
