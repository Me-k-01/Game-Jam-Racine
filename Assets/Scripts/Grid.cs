using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public Tile tilePrefab;
    private GameObject[,] data; // Matrice circulaire verticalement des objets 
    private Tile[,] tiles; // Matrice circulaire verticalement des objets 
    public int startY = 0; // Indice Y de départ de la matrice.
    public int width = 7; //
    public int height = 5;  
    public CameraMovement cameraMov;
    public Vector2Int selectedTile = new Vector2Int(0, 0);

    //public int blocDim = 1;
    public Vector3 topLeft = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start() { 
        data = new GameObject[width, height];
        tiles = new Tile[width, height];
        GenerateGrid();
        cameraMov.SetX(topLeft.x + 0.5f + (float)width/2);
    }
    void GenerateGrid() { 
        for (int x = 0; x < width ; x++) { 
            for (int y = 0; y < height ; y++) {
                Debug.Log("Generated tile : " + x + " , " + y); 
                var spawnedTile = Instantiate(tilePrefab, topLeft + new Vector3(x, -y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.Init(x, y);
                tiles[x, y] = spawnedTile;
                // Initialise tout à null
                data[x , y] = null;
            }
        }
    }
    public void Select(int i, int j) {
        selectedTile = new Vector2Int(i, j);
        //Debug.Log("i : " + i + "  j : " + j); 
    }
    public int ConvertY(int oldJ) {
        int j = oldJ + startY; 
        if (oldJ >= height) {
            return j - height;
        }
        /*if (oldJ < 0) {
            return gridSizeHeight;
        } */
        return j;
    }
    public void OnClick() {
        int i = selectedTile.x;
        int j = ConvertY(selectedTile.y);
        Debug.Log("Click event on : i : " + i + "  j : " + j); 
    }

    void Down() {
        // Fonction pour descendre vers le bas
        // On oublie donc la première ligne
        for (int x = 0; x < width; x++) {
            // TODO : delete object
            data[x, startY] = null; 
            Debug.Log(tiles[x, startY]);
            tiles[x, startY].transform.position = new Vector3(
                tiles[x, startY].transform.position.x,
                tiles[x, startY].transform.position.y - height,
                tiles[x, startY].transform.position.z
            );
        } 
        // On decremente la hauteur
        topLeft.y --; 
        // Et on incrémente la première ligne 
        startY ++;
        startY %= height; 
        //if (startY >= height) {
        //    startY = 0;
        //} 
        // TODO : faire descendre la camera lorsque l'on s'apporche ainsi du bord
        cameraMov.Move(topLeft.y + 0.5f + (float)height/2); 

    }
    // Update is called once per frame
    void Update() { 
        if (Input.GetButtonDown("Fire1")) {  
            OnClick();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Down();
        }
    }
}
