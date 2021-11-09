using In_Level.Level_Item_Behaviours.Ingestable;
using UnityEngine;

namespace In_Level.Fly.Fly_Passive_Abilities
{
    public class RecoveryBuff : BasePassiveAbility
    {
        private float FatValue = 0;
        private float ProteinValue = 0;
        private float CarbonHydrateValue = 0;
        protected override void Active()
        {
            if (FatValue != thisFlyController.IngestedValues[IngestTypes.Fat])
            {
                float diff = thisFlyController.IngestedValues[IngestTypes.Fat] - FatValue;
                diff = Mathf.Clamp(diff, 0, 100);
                thisFlyController.Heal(diff*0.1f);
                FatValue = thisFlyController.IngestedValues[IngestTypes.Fat];
            }
            if (ProteinValue != thisFlyController.IngestedValues[IngestTypes.Protein])
            {
                float diff = thisFlyController.IngestedValues[IngestTypes.Protein] - ProteinValue;
                diff = Mathf.Clamp(diff, 0, 100);
                thisFlyController.Heal(diff*0.1f);
                ProteinValue = thisFlyController.IngestedValues[IngestTypes.Protein];
            }
            if (CarbonHydrateValue != thisFlyController.IngestedValues[IngestTypes.CarbonHydrate])
            {
                float diff = thisFlyController.IngestedValues[IngestTypes.CarbonHydrate] - CarbonHydrateValue;
                diff = Mathf.Clamp(diff, 0, 100);
                thisFlyController.Heal(diff*0.1f);
                CarbonHydrateValue = thisFlyController.IngestedValues[IngestTypes.CarbonHydrate];
            }
        }
    }
}