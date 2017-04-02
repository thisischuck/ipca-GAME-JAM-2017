using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowMushroom : MonoBehaviour {

    public int speed;
    public GameObject player;
    public GameObject water;
    public GameObject ice;

    private Rigidbody2D rigidbody;

    private int aux;

    // Use this for initialization
    void Start () {

        aux = speed;
        ice.SetActive(false);
        rigidbody = this.GetComponentInParent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.GetComponent<Player>().weather == 1)
        { 
            transform.Translate(0, speed * Time.deltaTime, 0);
            water.SetActive(true);
            ice.SetActive(false);
        }
        else
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            water.SetActive(false);
            ice.SetActive(true);

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Collider" || collision.gameObject.tag == "Ground")
            aux = 0;
    }

}
