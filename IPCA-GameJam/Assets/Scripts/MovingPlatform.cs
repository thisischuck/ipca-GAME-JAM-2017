using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public GameObject gameObject;

	void Start () {
		gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 0));
	}

	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.name.Equals ("collider")) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-300, 0));
	}
		else if (collision.gameObject.name.Equals("fundo (1)"))
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(300, 0));
	}

}
