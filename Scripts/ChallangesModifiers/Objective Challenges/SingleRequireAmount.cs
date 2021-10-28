using System.Collections.Generic;
using Genral;
using In_Level.Level_Item_Behaviours;
using In_Level.UI;
using UnityEngine;

namespace ChallangesModifiers.Objective_Challenges
{
    public class SingleRequireAmount : BaseChallenge
    {
        public bool RequireAmountReached(BaseFlyController BFC, List<GameObject> GOs)
        {
            float sum = 0;
            foreach (var vallue in BFC.IngestedValues.Values)
            {
                sum += vallue;
            }

            return sum >= NeededVal;

        }
        
        [SerializeField]
        private string _name = "Filling Stomach";
        [SerializeField]
        private string _description = "600 unit of ingestion will be required for evacuation.";
        [SerializeField]
        private Modifier _difficultyModifier = new Modifier(ModifyOption.Additive, 0.5f, "a");
        
        private float NeededVal = 600;
        
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
            ObjectiveCheck IngestRequire = RequireAmountReached;
            FindObjectOfType<BaseObjectiveManager>().ObjectiveChecks.Add((_description, IngestRequire));
            FindObjectOfType<BaseIngestCompletionProgressBarManager>().TargetValue = NeededVal;
        }
    }
}