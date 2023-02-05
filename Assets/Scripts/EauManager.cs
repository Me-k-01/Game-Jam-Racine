using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EauManager : MonoBehaviour
{
    public TMP_Text texteau;
    public float eau;
    
    // Start is called before the first frame update
    void Start()
    {
        eau = 10f;
        texteau.text = eau.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        texteau.text = eau.ToString();
    }
}
