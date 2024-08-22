using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour, IMixedRealityPointerHandler
{

    public GameObject weatherSystem;

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if (weatherSystem.activeSelf)
            weatherSystem.SetActive(false);
        else weatherSystem.SetActive(true);
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
