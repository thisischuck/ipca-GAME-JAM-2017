using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    private Player player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //!col.gameObject.tag.Equals("Checkpoint") && !col.gameObject.tag.Equals("Door") &&
        if ( (col.gameObject.tag.Equals("Mushroom") || col.gameObject.tag.Equals("Ground")))
        {
            player.grounded = true;
        }
            
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if((col.gameObject.tag.Equals("Mushroom") || col.gameObject.tag.Equals("Ground")))
        {
            player.grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if((col.gameObject.tag.Equals("Mushroom") || col.gameObject.tag.Equals("Ground")))
        {
            player.grounded = false;
        }
    }
}
