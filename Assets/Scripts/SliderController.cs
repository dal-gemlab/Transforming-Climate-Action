using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    public RainScript rain;


    // Start is called before the first frame update
    void Start()
    {
        rain = GameObject.FindGameObjectWithTag("rain").GetComponent<RainScript>();

        _slider.value = 2.0f;

        _slider.onValueChanged.AddListener((v) =>
        {
            _sliderText.text = v.ToString("0.00");
            rain.RainIntensity = _slider.value;
            Debug.Log("Rain intensity is : " + _slider.value + " now.");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
