using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUpTerrain : MonoBehaviour
{
    public int nbrCases;
    public float width, height;
    public int gridWidth, gridHeight;
    public Vector3 offset, objectPosition;
    public float w_step, h_step;
    public List <GameObject> terrainObjects = new List<GameObject> ();
    public GameObject[,] terrainObject;

    //Demo
    public float[,] positions;
    // Start is called before the first frame update
    void Start()
    {
        width = Mathf.Max(transform.localScale.x, transform.localScale.y) * 10f;
        height = Mathf.Max(transform.localScale.x, transform.localScale.y) * 10f;
        nbrCases = 8;
        //GridSize
        gridWidth = 7;
        gridHeight = 7;
        //positions = new float[gridHeight, gridWidth];

        terrainObject = new GameObject[gridHeight,gridWidth];
        w_step = width / nbrCases;
        h_step = height / nbrCases;
        offset = new Vector3(-10f, 10f, 0f);
        objectPosition = transform.position + offset;

        List<Vector3> objectsPositions = new List<Vector3>();
        for (int i = 0; i < gridWidth; i++) 
        {
            for(int j = 0; j < gridHeight; j++)
            {
                objectsPositions.Add(objectPosition);
                //positions[i][j] = objectPosition;
                objectPosition = new Vector3(objectPosition.x + w_step, objectPosition.y, 0f);
            }
            objectPosition = new Vector3(offset.x, objectPosition.y - h_step, 0f);
        }
        
        /*for(int i = 0; i < nbrCases*nbrCases; ++i)
        {
            Debug.Log(objectsPositions[i]);
        }*/

        foreach(GameObject obj in terrainObjects) {
            //Retirer une case al�atoire dans la grille
            int n = UnityEngine.Random.Range(0, objectsPositions.Count);
            obj.transform.position = objectsPositions[n];
            objectsPositions.RemoveAt(n);
        }
    }
}
