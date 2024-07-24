using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaLevelInfoControl : MonoBehaviour
{
    public SeaLevelController seaLevel;
    public GameObject lineIndicator;
    private float moveSpeed = 0.184f;
    private float scalingSpeed = 0.003f;
    private float duration = 1.3f;
    private float elapseTime = 0f;
    private Vector3 initialScale;
    private Vector3 initialPosition;
    public GameObject infoBoard;

    // Start is called before the first frame update
    void Start()
    {
        seaLevel = GameObject.FindGameObjectWithTag("seaLevel").GetComponent<SeaLevelController>();
        initialScale = lineIndicator.transform.localScale;
        initialPosition = lineIndicator.transform.localPosition;

#if UNITY_EDITOR
        scalingSpeed = 0.000398f;

#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (seaLevel.rised)
        {
            if (elapseTime < duration)
            {
                lineIndicator.SetActive(true);
                lineIndicator.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

                Vector3 newScale = lineIndicator.transform.localScale;
                newScale.y += scalingSpeed;
                lineIndicator.transform.localScale = newScale;
                elapseTime += Time.deltaTime;
            }
            else
            {
                infoBoard.SetActive(true);
            }
        }
        else
        {
            lineIndicator.transform.localScale = initialScale;
            lineIndicator.transform.localPosition = initialPosition;
            lineIndicator.SetActive(false);
            elapseTime = 0f;
            infoBoard.SetActive(false);
        }
    }
}
