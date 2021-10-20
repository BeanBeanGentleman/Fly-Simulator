using UnityEngine;

namespace Control
{
    public class GluttonyBuff : BaseUltimateBuff
    {
        protected override void Active()
        {
            thisFlyController.IngestSpeed.SetModifier(this.guid, BuffValue[0]);
        }

        protected override void Deactive()
        {
            thisFlyController.IngestSpeed.SetNoBonusModifier(this.guid);
        }
    }
}