using System;
using Genral;
using UnityEngine;
using UnityEngine.UI;

namespace ChallangesModifiers.Fly_Debuff_Challanges
{
    public class EnervationII_FlyAgilityGreatlyDecrease : BaseChallenge
    {
        // public string Name = "Enervation";
        // public string Description = "The agility and moving acceleration of the fly will reduce.";
        // public Modifier DifficultyModifier = new Modifier(true, 1.3f, "z");
        
        
        [SerializeField]
        private string _name = "Enervation II";
        [SerializeField]
        private string _description = "The agility and moving acceleration of the fly will greatly reduce.";
        [SerializeField]
        private Modifier _difficultyModifier = new Modifier(true, 2f, "z");
        
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
            Modifier AgilityModifier = new Modifier(true, 0.3f, "z");
            var guid = Guid.NewGuid();
            GameObject.FindObjectOfType<BaseFlyController>().movementAccel.SetModifier(guid, AgilityModifier);
            GameObject.FindObjectOfType<BaseFlyController>().Agility.SetModifier(guid, AgilityModifier);
        }
    }
}