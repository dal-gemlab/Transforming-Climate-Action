using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    public GameObject halifax;
    public GameObject seaLevel;

    public PressableButton buttonUp;
    public PressableButton buttonDown;
    public PressableButton buttonLeft;
    public PressableButton buttonRight;
    public PressableButton buttonForward;
    public PressableButton buttonBackward;
    public TextMeshProUGUI showDif;
    public float xData, yData, zData;

    public float moveAmount = 0.01f; // Adjust as needed for HoloLens interaction


    // Start is called before the first frame update
    void Start()
    {
        buttonUp.ButtonPressed.AddListener(() => MoveObject(Vector3.up));
        buttonDown.ButtonPressed.AddListener(() => MoveObject(Vector3.down));
        buttonLeft.ButtonPressed.AddListener(() => MoveObject(Vector3.left));
        buttonRight.ButtonPressed.AddListener(() => MoveObject(Vector3.right));
        buttonForward.ButtonPressed.AddListener(() => MoveObject(Vector3.forward));
        buttonBackward.ButtonPressed.AddListener(() => MoveObject(Vector3.back));
    }

    // Update is called once per frame
    void Update()
    {
        showDif.text = "X: " + xData + " Y: " + yData + " Z: " + zData;
    }

    void MoveObject(Vector3 direction)
    {
        Debug.Log("presssss!!!!!!!");
        halifax.transform.position += direction * moveAmount;
        seaLevel.transform.position += direction * moveAmount;
        if(direction == Vector3.up)
        {
            yData += 0.01f;
        }
        else if(direction == Vector3.down) 
        {
            yData -= 0.01f;
        }
        else if(direction == Vector3.left)
        {
            xData -= 0.01f;
        }
        else if (direction == Vector3.right)
        {
            xData += 0.01f;
        }
        else if(direction == Vector3.forward)
        {
            zData += 0.01f;
        }
        else
        {
            zData -= 0.01f;
        }

    }

}
