using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsCheck : MonoBehaviour {

    private Player player;
    public Vector2 checkpoint;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
        //checkpoint = gameObject.GetComponent<Player>().spawn;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Checkpoint"))
        {
            checkpoint = new Vector2 (player.gameObject.transform.position.x, player.gameObject.transform.position.y);
        }   
    }
}
