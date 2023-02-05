using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int vie=10;
    public int eau=10;
    public int score=0;
 
    // Start is called before the first frame update
    void Start() {  
    }

    // Update is called once per frame 

    public void Moved() {
        eau --; 
        GameOverTest();
    }

    public void GameOverTest() {
        if ((vie<=0) ||(eau<=0)){
            Debug.Log("Perdu!");
            Application.Quit();
        }
    }
}
