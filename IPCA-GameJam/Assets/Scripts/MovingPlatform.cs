using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public GameObject gameObject;
    public GameObject collider1;
    public GameObject collider2;
    public int speed;


    void Start () {
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
	}

	void Update ()
    {
        if (gameObject.GetComponent<Rigidbody2D>().position.x + gameObject.GetComponent<BoxCollider2D>().size.x/2 > collider1.GetComponent<Rigidbody2D>().position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
        }

        if (gameObject.GetComponent<Rigidbody2D>().position.x - gameObject.GetComponent<BoxCollider2D>().size.x / 2  < collider2.GetComponent<Rigidbody2D>().position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
        }

    }

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.name.Equals ("collider")) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * speed);
	}
		else if (collision.gameObject.name.Equals("collider2"))
			gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
	}

}
