using System.Collections.Generic;
using Genral;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Control
{
    public class AfterBurnerBuff : BaseManeuverabilityBuff
    {
        public AutoResetCounter ActivationTime = new AutoResetCounter(3);
        public AutoResetCounter CDTime = new AutoResetCounter(10);
        public List<Modifier> BuffValue = new List<Modifier>(){new Modifier(true, 3, "a")};
        public List<Modifier> DebuffValue = new List<Modifier>(){new Modifier(true, 0.03f, "a")};
        
        protected override float Active()
        {
            thisFlyController.ForwardAccel.SetModifier(this.guid, BuffValue[0]);
            thisFlyController.Agility.SetModifier(this.guid, DebuffValue[0]);
            return 0;
        }

        protected override float Deactive()
        {
            thisFlyController.ForwardAccel.SetNoBonusModifier(this.guid);
            thisFlyController.Agility.SetNoBonusModifier(this.guid);
            return 0;
        }
    }
}