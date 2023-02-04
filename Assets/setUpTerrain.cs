using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUpTerrain : MonoBehaviour
{
    public int nbrCases;
    public float width, height;
    public Vector3 offset, objectPosition; 
    
    public List <GameObject> terrainObjects = new List<GameObject> ();
    // Start is called before the first frame update
    void Start()
    {
        width = Mathf.Max(transform.localScale.y, transform.localScale.z) * 10f;
        height = Mathf.Max(transform.localScale.y, transform.localScale.z) * 10f;
        nbrCases = 8; 
        offset = new Vector3(0f, 10f, 10f);
        List<Vector3> objectsPositions = new List<Vector3>();
        for (int i = 0; i < nbrCases; i++) 
        {
            for(int j = 0; j < nbrCases; j++)
            {
                //To work on!!!!!!!!!!!!!
                objectsPositions.Add(new Vector3(0f, i + width / nbrCases, j + height / nbrCases) - offset); //- offset);
                //Debug.Log(objectsPositions[j]);
            }
        }
        
        for(int i = 0; i < nbrCases*nbrCases; ++i)
        {
            Debug.Log(objectsPositions[i]);
        }

        foreach(GameObject obj in terrainObjects)
        {
            //Retirer une case aléatoire dans la grille
            int n = UnityEngine.Random.Range(0, objectsPositions.Count);
            obj.transform.position = objectsPositions[n];
            objectsPositions.RemoveAt(n);
        }
    }
}
