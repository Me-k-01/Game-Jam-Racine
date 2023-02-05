using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int vie;
    public int eau;

    private VieManager vieManager;
    private EauManager eauManager;
    // Start is called before the first frame update
    void Start() {
        vieManager= GameObject.Find("Canvas").GetComponent<VieManager>();
        eauManager= GameObject.Find("Canvas").GetComponent<EauManager>();
        vie=10;
        eau=10;

        vieManager.vie = vie;
        eauManager.eau =eau;
    }

    // Update is called once per frame 

    public void Moved() {
        eau --;
        eauManager.eau -= 1f;
    }

    void game_over()
    {
        if((vie==0) ||(eau==0)){
            Application.Quit();
        }
    }
}
