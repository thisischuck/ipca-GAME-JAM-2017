using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;
    public bool grounded;
	public bool jump, mover, movel;
    public int weather = 1; //1 - Quente, 2 - Frio
    public bool weatherDelay = false;
    public int weatherCounter = 0;
    public int weatherWait;

    public bool showE = false;
    public bool showASDF = false;
    public bool showClosed = false;
    public bool showIPush = false;
    public bool showItSays = false;
    public bool showPull = false;

    public bool hasGlasses = false;

    public bool firstLine = true;

    public bool finishLevel = false;

    private Rigidbody2D rb;
    private Animator anim;


	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
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

		anim.SetBool("jump", jump);
		anim.SetBool("mover", mover);
		anim.SetBool("movel", movel);
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

		if (rb.velocity.x < 0) {
			movel = true;
			if (rb.velocity.x < -maxSpeed)
				rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
		}

        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }

        //Change Wheather
        if (weatherCounter > 0)
            weatherCounter--;

        DelayChange();

        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z))
        {
            if (weather != 1)
            {
                weather = 1;
                weatherCounter = weatherWait;
            }

        }

        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
        {
            if (weather != 2)
            {
                weather = 2;
                weatherCounter = weatherWait;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Interagir
        if (other.gameObject.tag.Equals("E")) {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (showE == false) {
                    showE = true;
                    showASDF = false;
                    showClosed = false;
                    showIPush = false;
                    showItSays = false;
                    showPull = false;
                }else
                {
                    showE = false;
                }
            }
        }
        else if (other.gameObject.tag.Equals("Sign") && !hasGlasses)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (showASDF == false)
                {
                    showE = false;
                    showASDF = true;
                    showClosed = false;
                    showIPush = false;
                    showItSays = false;
                    showPull = false;
                }
                else
                {
                    showASDF = false;
                }
            }
        }
        else if (other.gameObject.tag.Equals("Door") && !hasGlasses && !firstLine)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (showClosed == false)
                {
                    showE = false;
                    showASDF = true;
                    showClosed = false;
                    showIPush = false;
                    showItSays = false;
                    showPull = false;
                    firstLine = true;
                }
                else
                {
                    showClosed = false;
                }
            }
        }
        else if (other.gameObject.tag.Equals("Door") && !hasGlasses && firstLine)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (showIPush == false)
                {
                    showE = false;
                    showASDF = true;
                    showClosed = false;
                    showIPush = false;
                    showItSays = false;
                    showPull = false;
                    firstLine = false;
                }
                else
                {
                    showIPush = false;
                }
            }
        }
        else if (other.gameObject.tag.Equals("Sign") && hasGlasses && firstLine)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (showItSays == false)
                {
                    showE = false;
                    showASDF = true;
                    showClosed = false;
                    showIPush = false;
                    showItSays = false;
                    showPull = false;
                    firstLine = false;
                }
                else
                {
                    showItSays = false;
                }
            }
        }
        else if (other.gameObject.tag.Equals("Sign") && hasGlasses && !firstLine)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (showPull == false)
                {
                    showE = false;
                    showASDF = true;
                    showClosed = false;
                    showIPush = false;
                    showItSays = false;
                    showPull = false;
                }
                else
                {
                    finishLevel = true;
                }
            }
        }
    }
}
