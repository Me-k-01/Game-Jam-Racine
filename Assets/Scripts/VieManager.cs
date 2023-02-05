using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VieManager : MonoBehaviour
{
    public TMP_Text textvie;
    public float vie;

    // Start is called before the first frame update
    void Start()
    {
        vie = 10f;
        textvie.text = vie.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textvie.text = vie.ToString();
    }
}
