using In_Level.Fly.Fly_Passive_Abilities;
using UnityEngine;

namespace In_Level.Fly.Fly_Abilities
{
    public class FuelInjectorBuff : BaseManeuverabilityBuff
    {
        public NATBBuff theNATBBuff;
        protected override void Active()
        {
            if (theNATBBuff != null)
            {
                theNATBBuff.FinalBonusMultiplier.SetModifier(guid, BuffValue[0]);
            }
            else
            {
                theNATBBuff = this.gameObject.GetComponent<NATBBuff>();
            }
        }

        protected override void Deactive()
        {
            if (theNATBBuff != null)
            {
                theNATBBuff.FinalBonusMultiplier.SetNoBonusModifier(guid);
            }
        }
    }
}