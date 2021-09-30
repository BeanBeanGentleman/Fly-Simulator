using System.Collections.Generic;
using Genral;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Control
{
    /// <summary>
    /// This is for the After Burner ability for the normal fly.
    /// This ability will greatly improve the speed of the fly at the cost of greatly reduced agility.
    /// </summary>
    public class AfterBurnerBuff : BaseManeuverabilityBuff
    {
        protected override void Active()
        {
            thisFlyController.ForwardAccel.SetModifier(this.guid, BuffValue[0]);
            thisFlyController.Agility.SetModifier(this.guid, DebuffValue[0]);
        }

        protected override void Deactive()
        {
            thisFlyController.ForwardAccel.SetNoBonusModifier(this.guid);
            thisFlyController.Agility.SetNoBonusModifier(this.guid);
        }
    }
}