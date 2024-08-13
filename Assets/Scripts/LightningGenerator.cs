using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightningGenerator : MonoBehaviour
{
    public GameObject lightningPref;
    private float xValue, zValue;
    private float yValue = 0.2f;
    private double xOffSet, zOffSet;
    private float interval = 2f;
    private float flashInterval = 0.1f;
    private float timer = 0f;
    private Quaternion instantiateRotation = Quaternion.Euler(0, 0, 90);
    private float xMin = -1.81f;
    private float xMax = 3.66f;
    private float zMin = 0.04f;
    private float zMax = 2.77f;


    // Start is called before the first frame update
    void Start()
    {
        generateLightning();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > interval)
        {
            generateLightning();
            timer = 0f;
        }
    }

    private void generateLightning()
    {
        System.Random random = new System.Random();
        xOffSet = random.NextDouble();
        zOffSet = random.NextDouble();
        xValue = xMin + (float)xOffSet * (xMax - xMin);
        zValue = zMin + (float)zOffSet * (zMax - zMin);
        GameObject lightning = Instantiate(lightningPref, new Vector3(xValue, yValue, zValue), instantiateRotation);

        // Start the coroutine to handle the flashing and destruction
        StartCoroutine(FlashAndDestroy(lightning));
    }

    private IEnumerator FlashAndDestroy(GameObject lightning)
    {
        // Flash on and off
        for (int i = 0; i < 3; i++)
        {
            lightning.SetActive(false);
            yield return new WaitForSeconds(flashInterval);
            lightning.SetActive(true);
            yield return new WaitForSeconds(flashInterval);
        }

        // Wait for a bit before destroying the object
        yield return new WaitForSeconds(interval / 3);

        // Destroy the lightning object
        Destroy(lightning);
    }
}
