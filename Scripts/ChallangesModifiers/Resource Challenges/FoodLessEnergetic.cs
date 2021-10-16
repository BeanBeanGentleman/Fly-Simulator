using Genral;
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
        private Modifier _difficultyModifier = new Modifier(true, 1.3f, "y");
        
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
            Debug.LogWarning("Low Calorie has not been implemented!");
            // TODO: Make Energetic food less valuable
        }
    }
}