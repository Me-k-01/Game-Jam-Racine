using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour { 
    public Grid grid;  
    public GameObject terrain;
    public List<GameObject> prefabs = new List<GameObject>();
    public GameObject[,] terrainObjects;
    public int size = 5; 
    
    private GameObject secondTerrain = null; 
    [Range(0, 1)]
    public float spawnChance = 0.5f;
    private Vector3 bottomRight;
    //[Range(0, 5)]
    //public int maxQuantity = 1;
    // Start is called before the first frame update
    void Start() {
        terrainObjects = new GameObject[grid.width, grid.height]; 
        secondTerrain = Instantiate(terrain, terrain.transform.position + new Vector3(0, -size, 0), terrain.transform.rotation);
        bottomRight = terrain.transform.position + new Vector3(size, -size, 0);
        for (int i = 0; i < grid.width; i++)  {
            for(int j = 0; j < grid.height; j++)  {
                terrainObjects[i, j] = null;
            }
        } 
        
        /*for(int i = 0; i < nbrCases*nbrCases; ++i)
        {
            Debug.Log(objectsPositions[i]);
        }*/
        /*
        foreach(GameObject obj in terrainObjects) {
            //Retirer une case al�atoire dans la grille
            int n = Random.Range(0, objectsPositions.Count);
            obj.transform.position = objectsPositions[n];
            objectsPositions.RemoveAt(n);
        }*/
        int dataId = grid.AddGameObjectGrid(ref terrainObjects);
        grid.AddDelegateOnNewRow(NewRow, dataId);
    }
    GameObject PickPrefab() {
        return prefabs[Random.Range(0, prefabs.Count-1)];
    }

    public GameObject[] NewRow(int j) {
        GameObject[] row = new GameObject[grid.width];
        if (Random.Range(0.0f, 1f) <= spawnChance) {
            // On fait spawn
            int i = Random.Range(0, grid.width); 
            GameObject prefab = PickPrefab();
            row[i] = Instantiate( prefab, grid.topLeft + new Vector3(i, -j, 0.4f), prefab.transform.rotation);
        }

        if (bottomRight.y > grid.topLeft.y) {
            secondTerrain.transform.position += new Vector3(0, -size, 0); 
            terrain.transform.position += new Vector3(0, -size, 0); 
            bottomRight.y -= size; 
        }

        return row;
    }   
}
