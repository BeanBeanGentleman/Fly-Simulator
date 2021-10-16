using System;
using Control;
using Genral;
using UnityEngine;

namespace ChallangesModifiers.Fly_Debuff_Challanges
{
    public class FlyManeuverabilityCD : BaseChallenge
    {
        // public string Name = "Enervation";
        // public string Description = "The agility and moving acceleration of the fly will reduce.";
        // public Modifier DifficultyModifier = new Modifier(true, 1.3f, "z");
        
        
        [SerializeField]
        private string _name = "Hindrance";
        [SerializeField]
        private string _description = "The Maneuverability ability of the fly will suffer greater cool down duration.";
        [SerializeField]
        private Modifier _difficultyModifier = new Modifier(true, 1.2f, "h");
        
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
            Modifier CDModifier = new Modifier(true, 1.5f, "z");
            var guid = Guid.NewGuid();
            foreach (var buf in GameObject.FindObjectsOfType<BaseManeuverabilityBuff>())
            {
                buf.CDTimeVal.SetModifier(guid, CDModifier);
            }
            
        }
    }
}