using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Genral;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Serialization;

namespace In_Level.Fly.Fly_Abilities
{
    /// <summary>
    /// This is for the After Burner ability for the normal fly.
    /// This ability will greatly improve the speed of the fly at the cost of greatly reduced agility.
    /// </summary>
    public class FlySlowDown : BaseManeuverabilityBuff
    {

        public BagCountManager bag_count_manager;
        int total_food = 0;
        private Modifier mod;
        float f;
        protected override void Active()
        {
            thisFlyController.movementAccel.SetNoBonusModifier(this.guid);
            thisFlyController.movementAccel.SetModifier(this.guid, mod);
        }

        protected override void Deactive()
        {
            thisFlyController.movementAccel.SetNoBonusModifier(this.guid);
        }

        private void Update()
        {
            int new_food = 0;
            for (int i = 0; i < 3; i++)
            {
                new_food += bag_count_manager.get_bag_count(i);
            }

            if (new_food == total_food)
            {
                return;
            }
            else
            {
                total_food = new_food;
                if (total_food == 0)
                {
                    Deactive();
                }
                else
                {
                    f = -0.1f * total_food;
                    mod = new Modifier(false, f, "0");
                    Active();
                }
            }
        }

    }
}