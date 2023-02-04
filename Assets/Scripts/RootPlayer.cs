using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPlayer : MonoBehaviour {   
    //public Transform start;
    public GameObject rootPrefab;
    private Vector3 topLeft;
    public CameraMovement cameraMov;
    //public Vector3 target;
    private int blocDimX = 2;
    private int blocDimY = 2;
    public int gridSizeWidth = 7;
    public int gridSizeHeight = 7;
    private int firstLine = 0;  
    private GameObject[,] instances; // Matrice des racines 

    public Color color;
    public int inc = 0; 

    void Start() {  
        //r = rootPrefab.GetComponent<RootGrow>();
        instances = new GameObject[gridSizeWidth, gridSizeHeight];
        for (int i = 0; i < gridSizeWidth; i++) {
            for (int j = 0; j < gridSizeHeight; j++) {
                instances[i, j] = null;
            }
        }
        Camera cam = GetComponent<Camera>();
        //blocDimX = (Screen.width / gridSizeWidth) ;
        //blocDimY = Screen.height / gridSizeHeight;
        //topLeft = cam.transform.position; //+ new Vector3(blocDimX, y, 3);
        topLeft = gameObject.transform.position;
        int firstI = 0;
        Vector3 firstPos = new Vector3(
            gameObject.transform.position.x + firstI * blocDimY, 
            gameObject.transform.position.y, 
            gameObject.transform.position.z
        );
          
        instances[firstI, 0] = CreateRoot(firstPos); 
        cameraMov.Move(topLeft.y + blocDimY/2 - blocDimY * (gridSizeHeight/2));
            //new Vector3(blocDimX * (gridSizeWidth/2), blocDimY * (gridSizeHeight/2), 0)); 
    }
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Vector3 mousePos = Input.mousePosition;  
            int i = (int)((mousePos.x / Screen.width) * (gridSizeWidth-1));
            int j = (int)((1 - (mousePos.y / Screen.height)) * (gridSizeHeight-1));
            Debug.Log("i: " + i + ", j: " + j);
            PlaceRoot(i, j);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            // TODO : i,j
            int i = 0;
            inc += 1;
            int j = inc;

            PlaceRoot(i, j);
        }
    }
    void PlaceRoot(int i, int j) {
        // Convertir les j pour utiliser les propriétés du tableau circulaire
        //j = (j + firstLine) %gridSizeHeight;
        j += firstLine;
        if (j > gridSizeHeight) {
            j -= gridSizeHeight;
        }

        // Verifier la validiter de la position
        // TODO : ajouter des impasses
        if (instances[i, j] != null) { // La case actuel est vide 
            return;
        } 
        // Et il existe une racine parmis les cases voisines a coté ou au dessus (jamais en dessous parce qu'on ne peut pas remonter)
        if ((i-1 < 0 || instances[i-1, j] == null) && // Gauche
            (i+1 > gridSizeWidth || instances[i+1, j] == null) && // Droite
            (j == firstLine || instances[i, j-1] == null)) { // Dessus
            return;
        } 
        Vector3 targetPos = topLeft + new Vector3(blocDimX * i, -blocDimY * j, 0);
        GameObject newRoot = CreateRoot(targetPos);
        instances[i, j] = newRoot;
        if (j > gridSizeHeight / 2) {
            // On oublie la première ligne
            for (int x = 0; x < gridSizeWidth; x++) {
                // TODO : delete object
                instances[x, firstLine] = null; 
            }
            topLeft += new Vector3(0, -blocDimY, 0);
            // On incrémente la première ligne 
            firstLine ++;
            // TODO : faire descendre la camera lorsque l'on s'apporche ainsi du bord
            cameraMov.Move(topLeft.y +blocDimY/2 - blocDimY * (gridSizeHeight/2)); 
        } 
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
