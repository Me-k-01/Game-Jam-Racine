using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player, currentPlane;
    public Camera camera;
    public Vector3 cameraOffset;
    public Vector3 nextPlaneOffset;
    public Vector3 offset, min, max;

    public bool changePlaneUp = false, changePlaneDown = false;
    // Start is called before the first frame update
    void Start()
    {
        //Mouvement du camera sur l'axe y
        nextPlaneOffset = new Vector3(0f, 20f, 0f);
        //Pour avoir les bords du plan
        offset = new Vector3(10f, -10f, 0f);
        min = transform.position - offset;
        max = transform.position + offset;
        //La position du camera en fonction du plan
        cameraOffset = new Vector3(0f, 0f, -16f);
        camera.transform.position = currentPlane.transform.position + cameraOffset;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Si la racine depasser les bords de plan, changer le plan à afficher

        //Ajouter des changements pour prendre le currentPlane
        if (player.transform.position.y > min.y)
        {
            changePlaneUp = true;
            
        }
        if(player.transform.position.y < max.y) 
        {
            changePlaneDown = true;
            
        }
        if(changePlaneDown)
        {
            Debug.Log("Down");
            camera.transform.position -= nextPlaneOffset;
            //Changer min ou currentplane
            min = max;
            max -= nextPlaneOffset;
            changePlaneUp = false;
            changePlaneDown = false;
        }
        if (changePlaneUp)
        {
            Debug.Log("Up");
            camera.transform.position += nextPlaneOffset;
            max = min;
            max += nextPlaneOffset;
            changePlaneUp = false;
            changePlaneDown = false;
        }
    }
}
