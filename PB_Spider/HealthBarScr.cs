using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HealthBarScr : MonoBehaviour
{
    // Start is called before the first frame update

    public Image healthBar;

    float lerpSpeed;

    float maxHealth = 100;
    float health = 3f;
    float min_health = 3f;
    bool was_pressed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Damage();
        var gamepad = Gamepad.current;
        if (gamepad.buttonWest.isPressed)
        {
            was_pressed = true;
        }
        else
        {
            if (was_pressed)
            {
                was_pressed = false;
                Heal(15f);
            }
        }
        health = Mathf.Max(health, min_health);
        if (health >= maxHealth)
        {
            health = maxHealth;
        }

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChange();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);

    }

    void ColorChange()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;
    }

    void Heal(float healing)
    {
        health = Mathf.Min(maxHealth, health + healing);
    }

    void Damage()
    {
        health -= 1f;
    }
}
