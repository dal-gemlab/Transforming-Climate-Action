using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherInfoController : MonoBehaviour
{
    public GameObject weatherSystem;
    public GameObject weatherInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weatherSystem.activeSelf)
        {
            weatherInfo.SetActive(true);
        }
        else
        {
            weatherInfo.SetActive(false);
        }
    }
}
