using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public Transform start;
    public float size;
    // Start is called before the first frame update
    void Start()
    { 
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(start.position, new Vector3(50, 50, 50));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
