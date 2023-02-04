using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraMovement : MonoBehaviour {
    public float speed = 2f; 
    private Vector3 moveToPosition;  
    private bool started = false; 

    // Start is called before the first frame update
    void Start() {
        moveToPosition = transform.position; 
    }

    // Update is called once per frame
    void Update() {
        // so we only want the movement to start when we decide
        if (!started) return;  
        // Move the camera into position
        transform.position = Vector3.Lerp(transform.position, moveToPosition, speed);
        
        // Ensure the camera always looks at the player
        //transform.LookAt(transform.parent);
    }
    public void Move(float targetY) {
        started = true;
        moveToPosition = new Vector3(transform.position.x, targetY, transform.position.z);
    }
}
