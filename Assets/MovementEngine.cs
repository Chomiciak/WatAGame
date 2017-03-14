using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementEngine : MonoBehaviour {

	public Text zycie_tekst = null;

	public Canvas can = new Canvas();

	public Canvas PanelZPunktami = new Canvas();

	public int speed = 3;

	public GameObject hamburger = null;

	void Start(){
		if(!PlayerPrefs.HasKey("punkty"))
			PlayerPrefs.SetInt ("punkty", 0);

		if(!PlayerPrefs.HasKey("zycie"))
			PlayerPrefs.SetInt ("zycie", 10);


	}


	int timer = 24;

	
	// Update is called once per frame
	void Update () {

		if (timer > 1) {
			timer -= 1;

		}else if(timer == 1){
			this.GetComponent < SpriteRenderer > ().color = 
				new Color (255, 255, 255);

		}




		Rigidbody2D body = GetComponent<Rigidbody2D> ();


		if(Input.GetKeyDown(KeyCode.W))
			body.velocity = new Vector2 (body.velocity.x, speed);
		if(Input.GetKeyDown(KeyCode.A))
			body.velocity = new Vector2 (-speed, body.velocity.y);
		if(Input.GetKeyDown(KeyCode.S))
			body.velocity = new Vector2 (body.velocity.x, -speed);
		if(Input.GetKeyDown(KeyCode.D))
			body.velocity = new Vector2 (speed, body.velocity.y);

	}


	void OnTriggerEnter2D(Collider2D c){
		if (c.name.Equals ("Floor"))
			koniecGry ();

		if(c.name.Contains("Cheeseburger")){
			Destroy (c.gameObject);

			PlayerPrefs.SetInt (
				"punkty", 
				PlayerPrefs.GetInt ("punkty") + 1
			);

			PanelZPunktami.GetComponentInChildren<Text> ().text 
			= "Masz tyle punktów: " + PlayerPrefs.GetInt("punkty");
		
			GameObject go = Instantiate (hamburger);
		
			go.transform.position = 
				new Vector2( 
					Random.Range (-7, 7), 
					Random.Range (-7, 7)
				);

		}


		if (c.name.Equals ("Enemy")) {

			this.GetComponent < SpriteRenderer > ().color = new Color (255, 0, 0);

			int z = PlayerPrefs.GetInt ("zycie");

			timer = 24;


			PlayerPrefs.SetInt ("zycie", z - 1);

			c.transform.position = new Vector3 (
				c.transform.position.x + 2,
				c.transform.position.y + 2,
				c.transform.position.z
			);

			zycie_tekst.text = "Twoje życie: "+PlayerPrefs.GetInt("zycie");

			if (PlayerPrefs.GetInt ("zycie") == 0)
				koniecGry ();

		}
	}	



	public void koniecGry(){
		Destroy (this.gameObject);
		can.GetComponent<Canvas> ().enabled = true;

		PlayerPrefs.SetInt ("zycie", 10);
		PlayerPrefs.SetInt ("punkty", 0);
	}

}

