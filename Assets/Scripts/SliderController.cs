using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public Image fillImage;
    public float percentage;
    public Color high, med, low;
    // Update is called once per frame
    void Update()
    {
        percentage = slider.value / slider.maxValue;
        if(percentage > 0.5f)
        {
            fillImage.color = high;
        }
        else if (percentage > 0.10f)
        {
            fillImage.color = med;
        }
        else 
        {
            fillImage.color = low;
        }
    }
}
