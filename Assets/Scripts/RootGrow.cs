using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class RootGrow : MonoBehaviour {

    public List<MeshRenderer> growMeshes;
    public float timeToGrow = 5; 
    [Range(0, 1)]
    public float minGrow = 0.2f;
    [Range(0, 1)]
    public float maxGrow = 0.97f;

    private List<Material> growMaterials = new List<Material>();
    //private bool fullyGrown; 
    public Material material;
    private bool isGrowing = false; 
    private bool isShrinking = false;

    // Start is called before the first frame update
    void Start() {
        for(int i = 0; i<growMeshes.Count; i++) {
            for(int j = 0; j<growMeshes[i].materials.Length; j++) {
                if (growMeshes[i].materials[j].HasProperty("_Grow")) {
                    growMeshes[i].materials[j].SetFloat("_Grow", minGrow);
                    growMaterials.Add(growMeshes[i].materials[j]);
                }
            }
        }
    }
    void Awake()
    {  
        //fullyGrown = false;
        StartGrow();
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
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            isGrowing = true;
        }
        if (isGrowing) {
            foreach(var mat in growMaterials) {
                float growVal = mat.GetFloat("_Grow");
                if (growVal < maxGrow) {
                    growVal += 1 / timeToGrow * Time.deltaTime;
                    mat.SetFloat("_Grow", growVal);
                    isGrowing = growVal < maxGrow;
                } 
            }
        }
        if (isShrinking) {
            foreach(var mat in growMaterials) {
                float growVal = mat.GetFloat("_Grow");
                if (growVal > minGrow) { 
                    growVal -= 1 / timeToGrow * Time.deltaTime;
                    mat.SetFloat("_Grow", growVal); 
                    isGrowing = growVal > minGrow;
                }
            }
        }
    }
    /*void Grow() {

        foreach(var mat in growMaterials) {
            float growVal = mat.GetFloat("_Grow");
            if (growVal < maxGrow) {
                growVal += 1 / timeToGrow * Time.deltaTime;
                mat.SetFloat("_Grow", growVal);
                isGrowing = growVal < maxGrow;
            }  
        }
    }*/
    public void StartGrow() {
        isGrowing = true;
    }
    public void StartShrink() {
        isGrowing = false;
    }
    /*public void StartGrow() { 
        for (int i=0; i < growMaterials.Count; i++) {
            StartCoroutine(Grow(growMaterials[i]));
        }
    }
    IEnumerator Grow(Material mat) {
        float growVal = mat.GetFloat("_Grow");
        if (!fullyGrown) {
            while (growVal < maxGrow) {
                growVal += 1 / (timeToGrow / refreshRate);
                mat.SetFloat("_Grow", growVal);
                yield return new WaitForSeconds(refreshRate);
            }
        } else {
            while (growVal > minGrow) {
                growVal -= 1 / (timeToGrow / refreshRate);
                mat.SetFloat("_Grow", growVal);
                yield return new WaitForSeconds(refreshRate);
            }
        }
        fullyGrown = growVal >= maxGrow;
    }*/
}
