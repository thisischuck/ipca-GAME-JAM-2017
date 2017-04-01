using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 250f;
    public bool grounded;
	public bool jump, mover, movel;
    public int weather = 1; //1 - Quente, 2 - Frio
    public bool weatherDelay = false;
    public bool death = false;
    public Vector2 spawn = new Vector2(0f, 0f);
    public Vector2 checkp;

    private Rigidbody2D rb;
    private Animator anim;
    public GameObject player;


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

        checkp = player.GetComponent<CheckpointsCheck>().checkpoint;

        if (Input.GetKeyDown(KeyCode.H))
        {
            death = true;
        }


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

		anim.SetBool("jump", jump);
		anim.SetBool("mover", mover);
		anim.SetBool("movel", movel);
                
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector2.up * jumpPower);
        }

        if (death)
        {
            Debug.Log(checkp);
            player.gameObject.transform.position = checkp;
            death = false;
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

		if (rb.velocity.x < 0) {
			movel = true;
			if (rb.velocity.x < -maxSpeed)
				rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
		}

		else
			movel = false;

		if (rb.velocity.x > 0) {
			mover = true;
			if (rb.velocity.x > maxSpeed)
				rb.velocity = new Vector2 (maxSpeed, rb.velocity.y);
		}

		else
			mover = false;

        
    }
}
