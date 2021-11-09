using System;
using Genral;
using In_Level.Level_Item_Behaviours.StaticThreat;
using UnityEngine;
using UnityEngine.UI;

namespace ChallangesModifiers.Threat_Challanges
{
    public class Overcooked_II_StoveOvenDamageIncrease : BaseChallenge
    {
        [SerializeField]
        private string _name = "Overcooked II";
        [SerializeField]
        private string _description = "The Damage from stove oven greatly increases. ";
        [SerializeField]
        private Modifier _difficultyModifier = new Modifier(false, 2f, "a");
        
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
            Modifier DMGModifier = new Modifier(ModifyOption.Multiplicative, 10f, "z"); // TODO: Need Inspection
            var guid = Guid.NewGuid();
            foreach (StoveOvenHeatZone zoone in FindObjectsOfType<StoveOvenHeatZone>())
            {
                zoone.DamageBaseValPerSec.SetModifier(guid, DMGModifier);
            }
        }
    }
}