using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour {

	public Camera MainCamera;
	public GameObject Player;
	
	protected Vector2 cameraOffset;
	
	// Use this for initialization
	void Start () {
		cameraOffset = MainCamera.transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void LateUpdate() {
		RepositionCamera();
	}
	
	void RepositionCamera() {
		MainCamera.transform.position = Player.transform.position;
	}
}
