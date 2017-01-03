using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEngine : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		Rigidbody2D body = GetComponent<Rigidbody2D> ();


		if(Input.GetKeyDown(KeyCode.W))
			body.velocity = new Vector2 (body.velocity.x, 5);
		if(Input.GetKeyDown(KeyCode.A))
			body.velocity = new Vector2 (-5, body.velocity.y);
		if(Input.GetKeyDown(KeyCode.S))
			body.velocity = new Vector2 (body.velocity.x, -5);
		if(Input.GetKeyDown(KeyCode.D))
			body.velocity = new Vector2 (5, body.velocity.y);
		

	}
}
