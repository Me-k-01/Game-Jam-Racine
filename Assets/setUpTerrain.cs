using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUpTerrain : MonoBehaviour
{
    public Vector3 offset, objectPosition;
    //pour obtenir des points de bord
    public Vector3 min, max;

    public List <GameObject> terrainObjects = new List<GameObject> ();
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> objectsPositions = new List<Vector3>();
        offset = new Vector3(9f, 9f, 9f);
        min = transform.position - offset;
        max = transform.position + offset;

        Debug.Log(min + "\n");
        Debug.Log(max);
        
        Debug.Log(new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z)));
        foreach(GameObject obj in terrainObjects){
            objectPosition = new Vector3(0, UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z));
            objectsPositions.Add(objectPosition);

            obj.transform.position = objectPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
