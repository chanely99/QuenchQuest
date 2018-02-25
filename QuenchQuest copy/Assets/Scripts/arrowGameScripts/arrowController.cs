using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour {
	Rigidbody2D rb; 
	public GameObject arrowPoint; 
	public float speed; 
	float x; 
	float y; 
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxisRaw ("Horizontal");
		y = Input.GetAxisRaw ("Vertical"); 
		transform.rotation = Quaternion.Euler (0, 0, 0);
		rb.velocity = new Vector2 (x, y).normalized * speed; 
	}
}
