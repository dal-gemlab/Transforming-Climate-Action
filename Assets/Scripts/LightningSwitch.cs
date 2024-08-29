using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSwitch : MonoBehaviour
{
    public GameObject lightnings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateLightning()
    {
        if (lightnings.activeSelf)
        {
            lightnings.SetActive(false);
        }
        else
        {
            lightnings.SetActive(true);
        }
    }
}
