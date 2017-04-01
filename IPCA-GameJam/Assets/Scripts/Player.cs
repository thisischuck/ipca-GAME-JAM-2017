using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;
    public bool grounded;
    public int weather = 1; //1 - Quente, 2 - Frio
    public bool weatherDelay = false;
    public int weatherCounter = 0;
    public int weatherWait;

    private Rigidbody2D rb;
    //private Animator anim;


	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //anim = gameObject.GetComponent<Animator>();
	}
	

	void Update () {
        //anim.SetBool("Grounded", grounded);
        //anim.SetFloat("Speed", Math.Abs(Input.GetAxis("Horizontal")));

        /*(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }*/

                        
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector2.up * jumpPower);
        }
    }


    void DelayChange()
    {

        if (weatherCounter == 0)
        {
            weatherDelay = false;
        }
        else
        {
            weatherDelay = true;
        }
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.AddForce(Vector2.right * speed * moveHorizontal);

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }

        //Change Wheather
        if (weatherCounter > 0)
            weatherCounter--;

        DelayChange();

        if ((Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z)) && !weatherDelay)
        {
            if (weather != 1)
            {
                weather = 1;
                weatherCounter = weatherWait;
            }

        }

        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X) && !weatherDelay)
        {
            if (weather != 2)
            {
                weather = 2;
                weatherCounter = weatherWait;
            }
        }
    }
}
