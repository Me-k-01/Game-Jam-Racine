using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSpawner : MonoBehaviour {   
    //public Transform start;
    public GameObject rootPrefab;
    public Vector3 target;
    public float blocSize = 2;
    public float size = 4;

    public Color color;
    private RootGrow r; 

    void Start() {  
        r = rootPrefab.GetComponent<RootGrow>();
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            CreateRoot(target);
            target += new Vector3(0, -blocSize, 0);
        }
    }
    void CreateRoot(Vector3 pos) {
        GameObject clone = Instantiate(rootPrefab, pos, rootPrefab.transform.rotation); //, Quaternion.identity);
        //clone.GetComponent<RootGrow>().StartGrow();
    }
    /*private void OnDrawGizmosSelected() {
        //Gizmos.color = Color.red;
        //Gizmos.DrawCube(start.position, new Vector3(50, 50, 50));
    }*/
    
}
