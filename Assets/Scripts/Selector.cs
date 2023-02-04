using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {
    public int blocDimX = 1;
    public int blocDimY = 1;
    public int gridSizeWidth = 6;
    public int gridSizeHeight = 6;

    // Start is called before the first frame update
    void Start() { 
    }

    // Update is called once per frame
    void Update() {
        Vector3 mousePos = Input.mousePosition;  
        int i = (int)((mousePos.x / Screen.width) * (gridSizeWidth-1));
        int j = (int)((1 - (mousePos.y / Screen.height)) * (gridSizeHeight-1));
        transform.position = new Vector3(i,-j,transform.position.z);
    }
}
