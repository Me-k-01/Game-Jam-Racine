using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int vie;
    public int eau;
    // Start is called before the first frame update
    void Start() {
        vie=10;
        eau=10;
    }

    // Update is called once per frame 

    public void Moved() {
        eau --;
    }

    void game_over()
    {
        if((vie==0) ||(eau==0)){
            Application.Quit();
        }
    }
}
