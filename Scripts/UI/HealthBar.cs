using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{   
    public Slider hp_bar;

    public Gradient gradient;

    public Image fill;

    // Default diffculty is 1
    private int difficulty = 1;
    float elapsed = 0f;
    private Dictionary<int, float> difficulty_to_hp_loss = new Dictionary<int, float>();

    private void Start()
    {
        difficulty_to_hp_loss[1] = 0.5f;
        difficulty_to_hp_loss[2] = 1f;
        difficulty_to_hp_loss[3] = 2f;
        setMaxValue(50f);
    }

    public void set_diff(int diff)
    {
        if (diff < 1 || diff > 3)
        {
            return;
        }
        else
        {
            difficulty = diff;
        }
    }

    private void Update()
    {
        float hp_loss = difficulty_to_hp_loss[difficulty];
        elapsed += Time.deltaTime;
        if (elapsed >= 1.0f)
        {
            elapsed = elapsed % 1f;
            decrease_val(hp_loss);
        }

        if (hp_bar.value <= 0)
        {
            // TODO
            // Call Game Over Scene
            SceneManager.LoadScene("Game Over");    
        }
    }

    private void decrease_val(float val)
    {
        hp_bar.value -= val;
    }


    public void setMaxValue(float value){
        hp_bar.maxValue = value;
        hp_bar.value = value;

        fill.color = gradient.Evaluate(1f);
    }

    public float getValue()
    {
        return hp_bar.value;
    }

    public void setValue(float value){
        hp_bar.value = value;
        fill.color = gradient.Evaluate(hp_bar.normalizedValue);
    }
}
