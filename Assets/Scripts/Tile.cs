using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public GameObject highlight;
    public Grid grid;
    public int i = 0;
    public int j = 0; 
    public void Init(int i, int j) {
        this.i = i;
        this.j = j;
    }

    // Start is called before the first frame update
    void Start() {
        highlight.SetActive(false); 
    }

    // Update is called once per frame
    void Update() {
    }

    void OnMouseEnter() {
        highlight.SetActive(true); 
        grid.Select(i, j);
    }

    void OnMouseExit() {
        highlight.SetActive(false);
    }
}
