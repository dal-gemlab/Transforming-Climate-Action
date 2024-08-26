using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour, IMixedRealityPointerHandler
{

    public GameObject weatherSystem;
    public GameObject clouds;

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if (weatherSystem.activeSelf)
        {
            weatherSystem.SetActive(false);
            foreach (Transform child in clouds.transform)
            {
                Renderer childRenderer = child.GetComponent<Renderer>();
                // Change the material color
                childRenderer.material.color = Color.white;
            }
        }
        else { 
            weatherSystem.SetActive(true);
            foreach (Transform child in clouds.transform)
            {
                Renderer childRenderer = child.GetComponent<Renderer>();
                // Change the material color
                childRenderer.material.color = new Color(0.3f, 0.3f, 0.3f, 1);
            }
        }
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

}
