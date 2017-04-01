using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glasses : MonoBehaviour {

    public GameObject player;
    public GameObject sign_desfocado;
    public GameObject sign_focado;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
            {
                player.GetComponent<Player>().hasGlasses = true;
                gameObject.SetActive(false);
            sign_desfocado.SetActive(false);
            sign_focado.SetActive(true);

            }
    }
}
