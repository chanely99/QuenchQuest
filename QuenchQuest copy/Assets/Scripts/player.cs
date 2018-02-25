using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    private bool isHit = false;
    private int lifecounter = 3;

    public float speed;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isHit == false)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            //Store the current vertical input in the float moveVertical.
            float moveVertical = Input.GetAxis("Vertical");

            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            rb2d.velocity = movement*speed;
        }
 
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        lifecounter--;
        // rb2d.AddForce(new Vector2(4,6));
        other.gameObject.SetActive(false);
        gameOver();
    }

    void gameOver()
    {
        gameObject.SetActive(false);
    }
}
