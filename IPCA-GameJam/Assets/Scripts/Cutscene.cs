using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Cutscene : MonoBehaviour {

    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;
    public GameObject frame5;
    public GameObject frame6;

    public int cont;
    private int aux;

    // Use this for initialization
    void Start () {
        aux = cont;
        frame1.gameObject.SetActive(true);
        frame2.gameObject.SetActive(false);
        frame3.gameObject.SetActive(false);
        frame4.gameObject.SetActive(false);
        frame5.gameObject.SetActive(false);
        frame6.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        cont--;
        if (cont == (aux / 6)*5)
        {
            frame1.gameObject.SetActive(false);
            frame2.gameObject.SetActive(true);
        }

        if (cont == (aux / 6) * 4)
        {
            frame2.gameObject.SetActive(false);
            frame3.gameObject.SetActive(true);
        }

        if (cont == (aux / 6) * 3)
        {
            frame3.gameObject.SetActive(false);
            frame4.gameObject.SetActive(true);
        }

        if (cont == (aux / 6) * 2)
        {
            frame4.gameObject.SetActive(false);
            frame5.gameObject.SetActive(true);
        }

        if (cont == (aux / 6))
        {
            frame5.gameObject.SetActive(false);
            frame6.gameObject.SetActive(true);
        }

        if (cont == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
