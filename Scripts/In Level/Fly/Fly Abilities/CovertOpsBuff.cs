using UnityEngine;

namespace Control
{
    /// <summary>
    /// This is for covert ops ability for the normal fly.
    /// This will greatly reduce the noise level of the fly.
    /// </summary>
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