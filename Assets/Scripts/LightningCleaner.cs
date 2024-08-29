using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCleaner : MonoBehaviour
{
    public GameObject lightningGenerator;
    public GameObject weatherSystem;
    private GameObject lightning;  


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightning = GameObject.Find("LightningPrefab(Clone)");

        if( lightning != null)
        {
            Debug.Log("ligntning found");
        }

        if ((!lightningGenerator.activeSelf || !weatherSystem.activeSelf )&& lightning != null)
        {
            Destroy(lightning);
            Debug.Log("Lightning destroyed");
        }    
    }
}
