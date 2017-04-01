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

        if ((Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z)) && !weatherDelay)
        {
            if (weather != 1)
            {
                weather = 1;
                Delay();
                
            }

        }

        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X) && !weatherDelay)
        {
            if (weather != 2)
            {
                weather = 2;
                Delay();
            }

        }

                
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector2.up * jumpPower);
        }
    }


    IEnumerator Delay()
    {
        weatherDelay = true;
        yield return new WaitForSecondsRealtime(2f);
        weatherDelay = false;
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
    }
}
