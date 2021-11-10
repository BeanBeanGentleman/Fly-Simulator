using UnityEngine;
using System;
using System.Collections;

namespace In_Level.Fly.Fly_Abilities
{
    /// <summary>
    /// This is for the After Burner ability for the normal fly.
    /// This ability will greatly improve the speed of the fly at the cost of greatly reduced agility.
    /// </summary>
    public class AfterBurnerBuff : BaseManeuverabilityBuff
    {
        protected override void Active()
        {
            thisFlyController.movementAccel.SetModifier(this.guid, BuffValue[0]);
        }

        protected override void Deactive()
        {
            thisFlyController.movementAccel.SetNoBonusModifier(this.guid);
        }


        private void Update()
        {
            
        }
    }
}