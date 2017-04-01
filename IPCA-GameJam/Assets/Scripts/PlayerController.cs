using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpSpeed;
    public GameObject player;
    public bool isTouchingGround;

    private Rigidbody2D rb;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        //rb.AddForce (movement * speed);
        rb.velocity = new Vector2(moveHorizontal * speed, 0.0f);


        if (Input.GetKey(KeyCode.Space))
        {

            if (isTouchingGround)
            {
                rb.AddForce(Vector2.up * jumpSpeed);
                isTouchingGround = false;
            }
        }
    }


    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("toca");
            isTouchingGround = true;
        }
        else
        {
            Debug.Log("toca");
            isTouchingGround = false;
        }
    }

}
