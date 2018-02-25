using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMoveClothes : MonoBehaviour {
	public bool movingLeft; 
	public int moveSpeed; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (movingLeft) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (!movingLeft) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (gameObject.transform.position.x > 10 || gameObject.transform.position.x < -10)
			Destroy (gameObject); 
	}
}
