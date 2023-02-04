using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        //Directional Light follows the camera
        transform.position = camera.transform.position;
    }

}
