using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTagTextPosition : MonoBehaviour
{
    public GameObject mainCamera;
    public float offSet;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * offSet ;
    }
}
