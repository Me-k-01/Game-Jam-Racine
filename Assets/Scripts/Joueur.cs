using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    private int vie;
    private int eau;
    // Start is called before the first frame update
    void Start()
    {
        vie=10;
        eau=10;
    }

    // Update is called once per frame
    void Update()
    {
        eau=eau-1;   
    }

    void OnCollisionEnter (Collision collision) {
        if(collision.collider.name=="Magma")
        {
            eau=eau-3;
        }
        if(collision.collider.name=="Insecte")
        {
            vie=vie-2;
        }
        if(collision.collider.name=="Roche")
        {
            eau=eau-1;
            vie=vie-1;
        }
        if(collision.collider.name=="Eau")
        {
            eau=10;
        }
    }

    void game_over()
    {
        if((vie==0) ||(eau==0)){
            Application.Quit();
        }
    }
}
