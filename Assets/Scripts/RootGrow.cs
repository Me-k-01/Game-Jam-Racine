using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class RootGrow : MonoBehaviour {

    public Tree tree; 
    public Material material; 

    // Start is called before the first frame update
    void Start()
    {  
        /*var k = tree.data as TreeEditor.TreeData; // as TreeData;
        k.root.adaptiveLODQuality = 1;
        k.root.enableAmbientOcclusion = true;
        k.root.distributionFrequency = 20;
        k.root.UpdateFrequency(k);*/
        /*foreach (var leaf in k.leafGroups)
        {
            leaf.distributionFrequency = 50;
            //leaf.UpdateMesh();
        }*/
        
        //k.UpdateMesh(tree.transform.worldToLocalMatrix, out null);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
