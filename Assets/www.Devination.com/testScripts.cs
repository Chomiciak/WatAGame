﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public Transform target;
	public float speed = 3f;
	public float attack1Range = 1f;
	public int attack1Damage = 1;
	public float timeBetweenAttacks;

	public void MoveToPlayer ()
	{
		//rotate to look at player
		transform.LookAt (target.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);

		//move towards player
		if (Vector3.Distance (transform.position, target.position) > attack1Range) 
		{
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}
	}


}
