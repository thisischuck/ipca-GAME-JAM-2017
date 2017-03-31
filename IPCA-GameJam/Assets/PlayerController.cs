﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpSpeed;
    public GameObject player;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        //rb.AddForce (movement * speed);
        rb.velocity = new Vector2(moveHorizontal * speed, 0.0f);


        bool touchingGround = Physics2D.OverlapPoint(player.transform.position, groundLayer);

        if (Input.GetKey(KeyCode.Space))
        {

            if (touchingGround)
            {
                rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);
                touchingGround = false;
            }
        }
    }
}