using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class enemyMove : MonoBehaviour {
	public Transform[] waypoints;
	int current = 0;
	
	public float speed = 0.3f;

	void FixedUpdate() {
		float distance = Vector2.Distance(transform.position, waypoints[current].position);
		if (distance > 0.1f || distance<-0.01f) {
		//if (transform.position!=waypoints[current].position) {
			Vector2 p = Vector2.MoveTowards(transform.position, waypoints[current].position, speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		} else {
			current = (current+1)%waypoints.Length;
		}
	}
	
	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "Player") {
			//Game Over
			SceneManager.LoadScene("gameOverScene");

		}
	}
}

