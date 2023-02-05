using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSpawner : MonoBehaviour {   
    //public Transform start;
    public GameObject rootPrefab;  
    //public Vector3 target; 
    public Grid grid; 
    private GameObject[,] instances; // Matrice des racines 
 
    public int inc = 0; 

    void Start() {  
        //r = rootPrefab.GetComponent<RootGrow>();
        instances = new GameObject[grid.width, grid.height];
        for (int i = 0; i < grid.width; i++) {
            for (int j = 0; j < grid.height; j++) {
                instances[i, j] = null;
            }
        }
        //cameraMov = mainCamera.GetComponent<CameraMovement>();
        //blocDimX = 10 / gridSizeWidth ;
        //blocDimY = 10 / gridSizeHeight;
        //topLeft = mainCamera.transform.position; //+ new Vector3(blocDimX, y, 3); 
        //topLeft.x = blocDimY * (gridSizeHeight/2);
        //topLeft += new Vector3(0, mainCamera.transform.position.x, 0)

        int firstI = 0; //gridSizeWidth/2;
        /*Vector3 firstPos = new Vector3(
            gameObject.transform.position.x + firstI * blocDimY, 
            gameObject.transform.position.y, 
            gameObject.transform.position.z
        );*/ 
        instances[firstI, grid.startY] = CreateRoot(grid.topLeft); 
        grid.AddGameObjectGrid(ref instances);
        grid.AddDelegateOnClick(OnTileClick);
        //cameraMov.Move(topLeft.y + blocDimY/2 - blocDimY * (gridSizeHeight/2));
            //new Vector3(blocDimX * (gridSizeWidth/2), blocDimY * (gridSizeHeight/2), 0)); 
    }
 
    void Update() {
        /*if (Input.GetButtonDown("Fire1")) {
            Vector3 mousePos = Input.mousePosition;  
            int i = (int)((mousePos.x / Screen.width) * gridSizeWidth);
            int j = (int)((1 - (mousePos.y / Screen.height)) * gridSizeHeight);
            Debug.Log("i: " + i + ", j: " + j);
            PlaceRoot(i, j);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            // TODO : i,j
            int i = 0;
            inc += 1;
            int j = inc % (gridSizeHeight-1);

            Debug.Log("i: " + i + ", j: " + j);
            PlaceRoot(i, j);
        }*/
    } 

    void OnTileClick(int i, int j, Vector3 pos) {
        // Convertir les j pour utiliser les propriétés du tableau circulaire
        //j = (j + firstLine) %gridSizeHeight;
        /*int j = grid.ConvertY(trueJ) ;  */ 
        //Debug.Log("currJ : " + j + "  prevJ : " + prevJ); 
        int prevJ = j <= 0 ? j-1 + grid.height : j-1; 
        //prevJ = grid.ConvertY(prevJ) ;

        // Verifier la validiter de la position
        // TODO : ajouter des impasses
        if (instances[i, j] != null) { // La case actuel est vide 
            return;
        }  
        Debug.Log("firstLine: " + grid.startY);
        Debug.Log("True: " + (instances[i, prevJ] == null));
        // Et il existe une racine parmis les cases voisines a coté ou au dessus (jamais en dessous parce qu'on ne peut pas remonter)
        if ((i-1 < 0 || instances[i-1, j] == null) && // Gauche
            (i+1 > grid.width || instances[i+1, j] == null) && // Droite
            ((prevJ == grid.startY -1) || instances[i, prevJ] == null)) { // Dessus
            return;
        } 
        //Vector3 targetPos = grid.topLeft + new Vector3( i, -j, 0);
        GameObject newRoot = CreateRoot(pos);
        instances[i, j] = newRoot;
 
        // Si on dépasse la moitié de l'écran, on scroll vers le bas
        /*
        if (trueJ > gridSizeHeight / 2) {
            // On oublie donc la première ligne
            for (int x = 0; x < gridSizeWidth; x++) {
                // TODO : delete object
                instances[x, firstLine] = null; 
            }
            topLeft += new Vector3(0, -blocDimY, 0);
            // On incrémente la première ligne 
            firstLine ++;
            if (firstLine >= gridSizeHeight) {
                firstLine = 0;
            } 
            // TODO : faire descendre la camera lorsque l'on s'apporche ainsi du bord
            //cameraMov.Move(topLeft.y +blocDimY/2 - blocDimY * (gridSizeHeight/2)); 
        } */
    }
    GameObject CreateRoot(Vector3 pos) {
        GameObject clone = Instantiate(rootPrefab, pos, rootPrefab.transform.rotation); //, Quaternion.identity);
        //clone.GetComponent<RootGrow>().StartGrow();
        return clone;
    }
    /*private void OnDrawGizmosSelected() {
        //Gizmos.color = Color.red;
        //Gizmos.DrawCube(start.position, new Vector3(50, 50, 50));
    }*/
    
}
