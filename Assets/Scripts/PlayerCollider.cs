using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {
    public PlayerStats playerStats;

    private VieManager vieManager;
    private EauManager eauManager;
    // Start is called before the first frame update
    void Start() {
        vieManager= GameObject.Find("Canvas").GetComponent<VieManager>();
        eauManager= GameObject.Find("Canvas").GetComponent<EauManager>();
    }

    // Update is called once per frame
    void Update() { 
    }

    void OnCollisionEnter (Collision collision) {
        if(collision.collider.tag == "Magma")  {
            playerStats.eau -= 3;
            eauManager.eau = playerStats.eau;
            Debug.Log("Collision Magma");
        }
        if(collision.collider.tag=="Insecte") {
            playerStats.vie -= 2;
            vieManager.vie = playerStats.vie;
            Debug.Log("Collision Insecte");
        }
        if(collision.collider.tag=="Roche") {
            playerStats.eau --;
            playerStats.vie --;
            vieManager.vie = playerStats.vie;
            eauManager.eau = playerStats.eau;
            Debug.Log("Collision Roche");
        }
        if(collision.collider.tag=="Eau") {
            playerStats.eau += 10;
            eauManager.eau = playerStats.eau;
            Debug.Log("Collision Eau");
        }
    }
}
