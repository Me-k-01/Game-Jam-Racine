using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player, previousPlane, currentPlane, nextPlane;
    public Camera camera;
    public Vector3 cameraOffset, previousPlaneCoords, nextPlaneCoords;
    public Vector3 offset, min, max;
    // Start is called before the first frame update
    void Start()
    {
        //Pour avoir les bords du plan
        offset = new Vector3(9f, 9f, 9f);
        min = transform.position - offset;
        max = transform.position + offset;

        //La position du camera en fonction du plan
        cameraOffset = new Vector3(-16f, 0f, 0f);
        camera.transform.position = currentPlane.transform.position + cameraOffset;

        previousPlaneCoords = currentPlane.transform.position + cameraOffset;
        nextPlaneCoords = currentPlane.transform.position + cameraOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //Si la racine depasser les bords de plan, changer le plan à afficher
        if(player.transform.position.y < min.y)
        {
            camera.transform.position = previousPlaneCoords;
        }
        if(player.transform.position.y > max.y) 
        {
            camera.transform.position = nextPlaneCoords;
        }
    }
}
