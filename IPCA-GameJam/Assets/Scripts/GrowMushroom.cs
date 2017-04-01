using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowMushroom : MonoBehaviour {

    public int speed;
    public GameObject player;
    private int aux;

    // Use this for initialization
    void Start () {
        aux = speed;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(player.GetComponent<Player>().weather == 1)
            transform.Translate(0, speed * Time.deltaTime, 0);
        else
        {
            speed = aux;
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Collider")
        speed = 0;
    }

}
