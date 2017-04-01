using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    private Player player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Death"))
        {
            player.death = true;
        }
    }
}