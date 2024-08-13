using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCleaner : MonoBehaviour
{
    public GameObject weatherSystem;
    private GameObject lightning;  


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightning = GameObject.Find("LightningPrefab(Clone)");

        if (!weatherSystem.activeSelf && lightning != null)
        {
            Destroy(lightning);
        }    
    }
}
