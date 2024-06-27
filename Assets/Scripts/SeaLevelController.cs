using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class SeaLevelController : MonoBehaviour, IMixedRealityPointerHandler
{
    private float riseSpeed = 0.02f;
    public GameObject seaLevel;
    private bool rised = false;
    private bool riseUp = false;
    private bool riseDown = false;
    private float lowerBound = -0.36f;
    private float upperBound = -0.38f;
    private float diff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        diff = transform.position.y - seaLevel.transform.position.y;

        if (diff < upperBound)
        {
            rised = true;
            riseUp = false;
        }
        if (diff > lowerBound)
        {
            rised = false;
            riseDown = false;
        }
        if (!rised && riseUp)
        {
            seaLevelUp();
        }
        if(rised && riseDown)
        {
            seaLevelDown();
        }
        
        
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if (!rised)
        {
            riseUp = true;
        }
        if (rised)
        {
            riseDown = true;
        }
        Debug.Log("Clicked");
    }

    public void seaLevelUp()
    {
        seaLevel.transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
    }

    public void seaLevelDown()
    {
        seaLevel.transform.Translate(Vector3.up * (-riseSpeed) * Time.deltaTime);
    }

    // Implement required IMixedRealityPointerHandler methods
    public void OnPointerDown(MixedRealityPointerEventData eventData) { }
    public void OnPointerDragged(MixedRealityPointerEventData eventData) { }
    public void OnPointerUp(MixedRealityPointerEventData eventData) { }

}
