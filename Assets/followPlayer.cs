using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    public Vector3 cameraPos1, cameraPos2, nextPlaneOffset;
    public float maxYPlane0, maxYPlane1;

    void Start()
    {
        //Mouvement du camera sur l'axe y pour le prochain plan
        nextPlaneOffset = new Vector3(0f, 20f, 0f);

        cameraPos1 = new Vector3(0f, 0f, -16f);
        cameraPos2 = new Vector3(0f, -20f, -16f);

        //A changer après
        maxYPlane0 = -10f; //valeur y max du bord du premier plan
        maxYPlane1 = -30f; //valeur y max du bord du deuxieme plan
    }

    void FixedUpdate()
    {
        //Si la racine depasser les bords de plan, changer le plan à afficher
        //1. Sur le premier plan
        if (player.transform.position.y > maxYPlane0 || player.transform.position.y < maxYPlane1)
        {
            //Debug.Log("here1");
            camera.transform.position = cameraPos1;
        }
        //Aller au deuxieme plan
        if (player.transform.position.y <= maxYPlane0 && player.transform.position.y > maxYPlane1)
        {
            //Debug.Log("here2");
            camera.transform.position = cameraPos2;
            //Retourner au premier plan---------> (0.2f correspond à une petite distance proche du bord pour vérifier que c'est assez proche)
            if(player.transform.position.y >= maxYPlane1 && player.transform.position.y <= (maxYPlane1 + 0.2f))
            {
                //Debug.Log("here3");
                player.transform.position += (nextPlaneOffset * 2);
                //camera.transform.position = cameraPos1;
            }
        }
        
    }
}
