using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public Tile tilePrefab;
    public int width; //
    public int height; 


    // Start is called before the first frame update
    void Start() { 
        GenerateGrid();
    }
    void GenerateGrid() { 
        for (int x = 0; x < width ; x++) { 
            for (int y = 0; y > -height ; y--) {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
