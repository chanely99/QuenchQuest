using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowPointController : MonoBehaviour {
	public arrowGameManager agm; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionStay2D(Collision2D coll){
		if (Input.GetKey (KeyCode.Space)) {
			agm.score++;
		}	
	}
}
