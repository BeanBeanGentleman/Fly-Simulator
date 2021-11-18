using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


namespace In_Level.Fly.Fly_Abilities
{
    public class StaminaBar : BaseManeuverabilityBuff
    {
        public Image healthBar;
        public SpeedUpmAN sp_man;

        float lerpSpeed;

        float maxHealth = 100f;
        float health = 100f;
        float min_health = 2f;
        bool was_pressed;
        protected override void Active()
        {
            thisFlyController.movementAccel.SetModifier(this.guid, BuffValue[0]);
        }

        protected override void Deactive()
        {
            thisFlyController.movementAccel.SetNoBonusModifier(this.guid);
        }

        // Update is called once per frame
        void Update()
        {
            var gamepad = Gamepad.current;
            if (gamepad.buttonNorth.isPressed)
            {
                was_pressed = true;
            }
            else
            {
                was_pressed = false;
            }

            if (was_pressed)
            {
                if (health > 5f)
                {
                    SpeedUp();
                }
            }
            else
            {
                Heal(0.2f);
            }

            if (!was_pressed || health <= 5f)
            {
                SlowDown();
            }



            lerpSpeed = 3f * Time.deltaTime;

            HealthBarFiller();
        }


        void HealthBarFiller()
        {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);

        }


        void Heal(float healing)
        {
            health = Mathf.Min(maxHealth, health + healing);
        }

        void Damage(float damage)
        {
            health = Mathf.Max(min_health, health - damage);
        }

        void SpeedUp()
        {
            sp_man.set_speed_up();
            Damage(1f);
            Active();
        }

        void SlowDown()
        {
            sp_man.unset_speed_up();
            Deactive();
            Heal(0.06f);
        }

    }
}
