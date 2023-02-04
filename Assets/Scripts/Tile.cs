using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public GameObject highlight;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
    }

    void OnMouseEnter() {
        highlight.SetActive(true); 
    }

    void OnMouseExit() {
        highlight.SetActive(false);
    }
}
