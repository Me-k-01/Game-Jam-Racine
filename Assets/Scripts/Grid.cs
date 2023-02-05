using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public Tile tilePrefab;

    public delegate void DelegateOnCLick( int i, int j, Vector3 pos);
    public delegate GameObject[] DelegateNewRow( );
    private List<GameObject[,]> data = new List<GameObject[,]>(); // Liste des matrices circulaires verticalement des game objets 
    private List<DelegateOnCLick> methodsOnClick = new List<DelegateOnCLick>(); // Methodes a appeller lors d'un event click
    private List<DelegateNewRow> methodsNewRow = new List<DelegateNewRow>(); // Methodes a appeller lors d'un event nouvelle ligne
    private Tile[,] tiles; // Matrice circulaire verticalement des objets 
    public int startY = 0; // Indice Y de départ de la matrice.
    public int width = 7; //
    public int height = 7;  
    public CameraMovement cameraMov;
    public Vector2Int selectedTile = new Vector2Int(0, 0);

    //public int blocDim = 1;
    public Vector3 topLeft = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start() { 
        data.Add(new GameObject[width, height]);
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
                //data[0][x , y] = null; // Matrice des objets, circulaire verticalement   
            }
        }
    }

    public void AddGameObjectGrid(ref GameObject[,] grid) {
        data.Add(grid);
    }
    public void AddDelegateOnClick(DelegateOnCLick OnClick) {
        methodsOnClick.Add(OnClick);
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
        //Debug.Log("Click event on : i : " + i + "  j : " + j); 
        foreach (var onClick in methodsOnClick) {
            Vector3 pos = topLeft + new Vector3( i, -j, 0);
            onClick(i, j, pos);Debug.Log("oncl");
        } 
    }

    void ClearRow(int y) {
        // On oublie donc la première ligne
        for (int x = 0; x < width; x++) {
            // TODO : delete object 
            foreach (var d in data) {
                d[x, y] = null;  
            }

            //Debug.Log(tiles[x, y]);
            tiles[x, y].transform.position = new Vector3(
                tiles[x, y].transform.position.x,
                tiles[x, y].transform.position.y - height,
                tiles[x, y].transform.position.z
            );
        } 
    }

    void Down() { // Fonction pour descendre vers le bas
        ClearRow(startY); 
        // On decremente la hauteur
        topLeft.y --; 
        // Et on incrémente la première ligne 
        startY ++;
        startY %= height; 
        //if (startY >= height) {
        //    startY = 0;
        //} 
        // TODO : faire descendre la camera lorsque l'on s'apporche ainsi du bord
        cameraMov.Move(topLeft.y - 0.5f - (float)height/2); 
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
