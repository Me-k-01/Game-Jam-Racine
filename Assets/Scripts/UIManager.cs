using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    public TMP_Text textEau;
    public TMP_Text textVie;
    public PlayerStats playerStats;
    
    // Start is called before the first frame update
    void Start() { 
        textEau.text = playerStats.eau.ToString();
        textVie.text = playerStats.vie.ToString();
    }

    // Update is called once per frame
    void Update() {
        textEau.text = playerStats.eau.ToString();
        textVie.text = playerStats.vie.ToString();
    }
}
