using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour {

    public GameObject other;

    private int cont;
    private bool state;


	// Use this for initialization
	void Start () {
        cont = 30;
        state = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(cont <= 0)
        {
            cont = 30;
            other.SetActive(!other.activeInHierarchy);

        }
        else
        {
            cont--;
        }
    }
}
