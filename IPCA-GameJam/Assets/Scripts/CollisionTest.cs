using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

    public GameObject ground;
    public GameObject player;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnColliderEnter(Collider2D collision)  
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("toca");
            collision.gameObject.GetComponent<PlayerController>().isTouchingGround = true;
        }
        else
        {
            Debug.Log("toca");
            collision.gameObject.GetComponent<PlayerController>().isTouchingGround = false;
        }
    }
}
