using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() { 
    }

    void OnCollisionEnter (Collision collision) {
        if(collision.collider.name == "Magma")  {
            playerStats.eau -= 3;
            Debug.Log("Collision Magma");
        }
        if(collision.collider.name=="Insecte") {
            playerStats.vie -= 2;
            Debug.Log("Collision Insecte");
        }
        if(collision.collider.name=="Roche") {
            playerStats.eau --;
            playerStats.vie --;
            Debug.Log("Collision Roche");
        }
        if(collision.collider.name=="Eau") {
            playerStats.eau += 10; 
            Debug.Log("Collision Eau");
        }
    }
}
