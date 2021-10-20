using System;
using Genral;
using In_Level.Level_Item_Behaviours.Ingestable;
using In_Level.Level_Item_Behaviours.StaticThreat;
using UnityEngine;

namespace ChallangesModifiers.Resource_Challenges
{
    public class FoodMuchLessExposed : BaseChallenge
    {
        [SerializeField]
        private string _name = "Tidy Up";
        [SerializeField]
        private string _description = "Much less food resources exposed outside. ";
        [SerializeField]
        private Modifier _difficultyModifier = new Modifier(ModifyOption.Multiplicative, 2.5f, "y");
        
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
            foreach (BaseIngestable ingestable in FindObjectsOfType<BaseIngestable>())
            {
                if (ingestable != null && ingestable.gameObject != null)
                {
                    if (ingestable.ExposureLevel > 5)
                    {
                        ingestable.RemoveParent();
                    }
                }
            }
        }
    }
}