using System;
using Genral;
using In_Level.Level_Item_Behaviours.Ingestable;
using In_Level.Level_Item_Behaviours.StaticThreat;
using UnityEngine;

namespace ChallangesModifiers.Resource_Challenges
{
    public class FoodLessExposed : BaseChallenge
    {
        [SerializeField]
        private string _name = "Place Back";
        [SerializeField]
        private string _description = "Less food resources exposed outside. ";
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
            foreach (BaseIngestable ingestable in FindObjectsOfType<BaseIngestable>())
            {
<<<<<<< HEAD
                if (ingestable.ExposureLevel > 8)
                {
                    ingestable.RemoveParent();
=======
                if (ingestable != null && ingestable.gameObject != null)
                {
                    if (ingestable.ExposureLevel > 8)
                    {
                        ingestable.RemoveParent();
                    }
>>>>>>> dev_tony
                }
            }
        }
    }
}