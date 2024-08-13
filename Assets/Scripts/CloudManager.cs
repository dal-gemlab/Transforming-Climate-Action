using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    private float horrizontalSpeed, verticalSpeed;
    private float speed = 0.05f;
    private float leftBound = -1.35f;
    private float upBound = 1.27f;
    private float rightBound = 2f;
    private float downBound = 0f;

    void Start()
    {
        horrizontalSpeed = speed;
        verticalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x < leftBound)
        {
            horrizontalSpeed = speed;
        }
        else if(transform.position.x > rightBound)
        {
            horrizontalSpeed = -speed;
        }

        if (transform.position.z > upBound)
        {
            verticalSpeed = -speed;
        }
        else if (transform.position.z < downBound)
        {
            verticalSpeed = speed;
        }

        transform.Translate(horrizontalSpeed * Time.deltaTime, 0, verticalSpeed * Time.deltaTime);

    }
}
