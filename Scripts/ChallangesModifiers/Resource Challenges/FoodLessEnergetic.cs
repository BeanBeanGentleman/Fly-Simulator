using System;
using Genral;
using In_Level.Level_Item_Behaviours.Ingestable;
using UnityEngine;

namespace ChallangesModifiers.Resource_Challenges
{
    public class FoodLessEnergetic : BaseChallenge
    {
        [SerializeField]
        private string _name = "Low Calorie";
        [SerializeField]
        private string _description = "Food resources offer less Fat, Protein or CarbonHydrate. ";
        [SerializeField]
        private Modifier _difficultyModifier = new Modifier(ModifyOption.Multiplicative, 1.3f, "y");
        
        public override string Name
        {
            get => _name;
            set => _name = value;
        }

        public override string Description
        {
            get => _description;
            set => _description = value;
        }

        public override Modifier DifficultyModifier
        {
            get => _difficultyModifier;
            set => _difficultyModifier = value;
        }

        public override void OnLevelLoaded()
        {
            Modifier AmountModifier = new Modifier(ModifyOption.Multiplicative, 1.5f, "z");
            var guid = Guid.NewGuid();
            foreach (BaseIngestable ingestable in FindObjectsOfType<BaseIngestable>())
            {
                if (ingestable.MyType == IngestTypes.Fat || ingestable.MyType == IngestTypes.Protein || ingestable.MyType == IngestTypes.CarbonHydrate)
                {
                    ingestable.UpdateMaxAmount(guid, AmountModifier);
                }
            }
            
        }
    }
}