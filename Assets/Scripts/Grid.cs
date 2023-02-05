using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public Tile tilePrefab;

    public delegate void DelegateOnCLick( int i, int j, Vector3 pos);
    public delegate GameObject[] DelegateNewRow(int j);
    private List<GameObject[,]> data = new List<GameObject[,]>(); // Liste des matrices circulaires verticalement des game objets 
    private List<DelegateOnCLick> methodsOnClick = new List<DelegateOnCLick>(); // Methodes a appeller lors d'un event click
    //private List<int> methodsOnClickData = new List<int>();
    private List<DelegateNewRow> methodsNewRow = new List<DelegateNewRow>(); // Methodes a appeller lors d'un event nouvelle ligne
    private List<int> methodsNewRowData = new List<int>();

    private int[] dataIndex; // Correspondance de chaque index pour les données de data 
    private Tile[,] tiles; // Matrice circulaire verticalement des objets 
    public int startY = 0; // Indice Y de départ de la matrice.
    public int endY = 0;
    public int width = 7; //
    public int height = 7;  
    public CameraMovement cameraMov;
    public Vector2Int selectedTile = new Vector2Int(0, 0);

    //public int blocDim = 1;
    public Vector3 topLeft = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start() { 
        //data.Add(new GameObject[width, height]);
        dataIndex = new int[height];
        for (int i = 0; i < height; i++) {
            dataIndex[i] = i; 
        }
        tiles = new Tile[width, height];
        GenerateGrid();
        cameraMov.SetX(topLeft.x + (float)width/2);
    }
    void GenerateGrid() { 
        for (int x = 0; x < width ; x++) { 
            for (int y = 0; y < height ; y++) {
                //Debug.Log("Generated tile : " + x + " , " + y); 
                var spawnedTile = Instantiate(tilePrefab, topLeft + new Vector3(x, -y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.Init(x, y);
                tiles[x, y] = spawnedTile;
                // Initialise tout à null
                //data[0][x , y] = null; // Matrice des objets, circulaire verticalement   
            }
        }
    }

    public int AddGameObjectGrid(ref GameObject[,] grid) {
        data.Add(grid); 
        return data.Count -1;
    }
    public void AddDelegateOnClick(DelegateOnCLick OnClick) {
        methodsOnClick.Add(OnClick);
    }
    public void AddDelegateOnNewRow(DelegateNewRow OnNewRow, int numData) {
        methodsNewRow.Add(OnNewRow);
        methodsNewRowData.Add(numData);
    }

    public void Select(int i, int j) {
        selectedTile = new Vector2Int(i, j);
        //Debug.Log("i : " + i + "  j : " + j); 
    }
    public int ConvertY(int oldJ) {
        int j = oldJ + startY; 
        if (j >= height) {
            return j - height;
        }
        /*if (j < 0) {
            return j + height;
        } */
        return j;
    }
    // TODO : trouver une meilleur solution
    int GetIndex(int j) {
        return dataIndex[j];
    }

    public void OnClick() {
        int i = selectedTile.x;
        int j = selectedTile.y;  
        //Print2DArray(data[0]);
        //Debug.Log("Click event on : i : " + selectedTile.x + "  j : " + selectedTile.y); 
        foreach (var onClick in methodsOnClick) {
            Vector3 pos = topLeft + new Vector3( i, -j, 0);
            onClick(i, j, pos); 
        } 
    }

    void ClearRow(int y) {
        // On oublie donc la première ligne
        foreach (var d in data) {
            for (int x = 0; x < width; x++) { 
                Destroy(d[x, 0]);
                d[x, 0] = null;    
            /*
            // Déplacer en bas
            tiles[x, y].transform.position = new Vector3(
                tiles[x, y].transform.position.x,
                tiles[x, y].transform.position.y - height,
                tiles[x, y].transform.position.z
            );  */
            }  

  
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height -1; j++) { 
                    d[i, j] = d[i, j+1];
                } 
            } 
            for (int i = 0; i < width; i++) {
                d[i, height -1] = null;
            }
        }
        // Update data index, le dernier deviens le premier, et on incremente le reste
        /*for (int i = 0; i < height; i++) {
            dataIndex[i] ++;
            if (dataIndex[i] >= height) {
                dataIndex[i] = 0;
            } 
        }*/
        // TODO : Ça fait 5h et j'arrive pas à faire autrement, à l'aide.
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                // Déplacer en bas
                tiles[i, j].transform.position = new Vector3(
                    tiles[i, j].transform.position.x,
                    tiles[i, j].transform.position.y - 1,
                    tiles[i, j].transform.position.z
                );  
            }
        }
    } 

    public void NewRow(int y) {
        for (int i = 0; i < methodsNewRowData.Count ; i++) {
            
            GameObject[] row = methodsNewRow[i](y);
            int index = methodsNewRowData[i];
            for (int x = 0; x < width; x++) { 
                data[index][x, y] = row[x];
            }
        }
    }

    public void Down() { // Fonction pour descendre vers le bas
        ClearRow(startY); 
        NewRow(height -1);
        // On decremente la hauteur
        topLeft.y --; 
        // Et on incrémente la première ligne 
        startY ++;
        startY %= height; 
        //if (startY >= height) {
        //    startY = 0;
        //} 
        // TODO : faire descendre la camera lorsque l'on s'approche du bord
        cameraMov.Move(topLeft.y + 0.5f - (float)height/2); 
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
