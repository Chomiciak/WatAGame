using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tlo : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		GetComponent<Camera> ().backgroundColor = new Color (
			Random.Range (0.0f, 1.0f), 
			Random.Range (0.0f, 1.0f), 
			Random.Range (0.0f, 1.0f)
		);
	}
}
