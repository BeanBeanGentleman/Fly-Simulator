using System;
using Genral;
using In_Level.Level_Item_Behaviours.StaticThreat;
using UnityEngine;
using UnityEngine.UI;

namespace ChallangesModifiers.Threat_Challanges
{
    public class Fickle_Fridge_FridgeStackupSpeedIncrease : BaseChallenge
    {
        // public string Name = "Fickle Fridge";
        // public string Description = "The Effect from fridge stackup faster. ";
        // public Modifier DifficultyModifier = new Modifier(false, 0.5f, "a");
        
        
        [SerializeField]
        private string _name = "Fickle Fridge I";
        [SerializeField]
        private string _description = "The Effect from fridge stackup faster. ";
        [SerializeField]
        private Modifier _difficultyModifier = new Modifier(false, 0.5f, "a");
        
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
            Modifier StackSpeedModifier = new Modifier(ModifyOption.Multiplicative, 3f, "z");
            var guid = Guid.NewGuid();
            foreach (StaticFreezer zoone in FindObjectsOfType<StaticFreezer>())
            {
                zoone.MobilityReductionStackSpeedMultiplier.SetModifier(guid, StackSpeedModifier);
            }
        }
    }
}