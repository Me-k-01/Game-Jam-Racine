using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {
    public float blocDimX = 0.2558503f;
    public float blocDimY = 0.2558503f;
    public int gridSizeWidth = 7;
    //public int gridSizeHeight = 7;
    public Vector3 topLeft;


    // Start is called before the first frame update
    void Start() { 
        topLeft = transform.position; 
    }

    // Update is called once per frame
    void Update() {
        Vector3 mousePos = Input.mousePosition;  
        int i = (int)((mousePos.x / Screen.width) * gridSizeWidth);
        float gridSizeHeight = Screen.width / blocDimY ;
        int j = (int)(mousePos.x / blocDimY) ;
        Debug.Log("i: " + i + ", j: " + j);
        //int j = (int)((1 - (mousePos.y / Screen.height)) * gridSizeHeight);
        mousePos.x = ((float)i+0.5f) * (Screen.width  / gridSizeWidth);
        mousePos.y = ((1.0f - ((float)j/gridSizeHeight))  ) * Screen.height;
        mousePos.z = Camera.main.nearClipPlane + 1;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = worldPos; //new Vector3(topLeft.x + i, topLeft.y-j, topLeft.z);
    }
}
