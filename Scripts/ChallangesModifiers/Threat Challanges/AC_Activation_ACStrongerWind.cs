using System;
using Genral;
using In_Level.Level_Item_Behaviours.StaticThreat;
using UnityEngine;
using UnityEngine.UI;

namespace ChallangesModifiers.Threat_Challanges
{
    public class AC_Activation_ACStrongerWind : BaseChallenge
    {
        // public string Name = "AC Activation";
        // public string Description = "The wind strength of the Air Conditioner increases.";
        // public Modifier DifficultyModifier = new Modifier(false, 0.5f, "a");
        
        
        
        [SerializeField]
<<<<<<< HEAD
        private string _name = "AC Activation";
=======
        private string _name = "AC Activation I";
>>>>>>> dev_tony
        [SerializeField]
        private string _description = "The wind strength of the Air Conditioner increases.";
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
<<<<<<< HEAD
            Modifier ForceModifier = new Modifier(ModifyOption.Multiplicative, 1.5f, "z");
=======
            Modifier ForceModifier = new Modifier(ModifyOption.Multiplicative, 3f, "z");
>>>>>>> dev_tony
            var guid = Guid.NewGuid();
            foreach (CoolAirWindZone zoone in FindObjectsOfType<CoolAirWindZone>())
            {
                zoone.WindStrength.SetModifier(guid, ForceModifier);
            }
        }
    }
}