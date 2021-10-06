using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    public Slider hp_bar;

    public Gradient gradient;

    public Image fill;

    public void setMaxValue(float value){
        hp_bar.maxValue = value;
        hp_bar.value = value;

        fill.color = gradient.Evaluate(1f);
    }

    public void setValue(float value){
        hp_bar.value = value;
        fill.color = gradient.Evaluate(hp_bar.normalizedValue);
    }
}
