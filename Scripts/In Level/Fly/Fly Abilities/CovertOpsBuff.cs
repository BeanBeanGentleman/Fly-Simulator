using UnityEngine;

namespace Control
{
    public class CovertOpsBuff : BaseSurvivabilityBuff
    {
        protected override void Active()
        {
            thisFlyController.NoiseLevel.SetModifier(this.guid, BuffValue[0]);
        }

        protected override void Deactive()
        {
            thisFlyController.NoiseLevel.SetNoBonusModifier(this.guid);
        }
    }
}