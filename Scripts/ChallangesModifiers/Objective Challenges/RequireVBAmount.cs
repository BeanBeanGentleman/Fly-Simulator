using System;
using System.Collections.Generic;
using Genral;
using In_Level.Level_Item_Behaviours.Ingestable;
using In_Level.UI;
using UnityEngine;

namespace ChallangesModifiers.Objective_Challenges
{
    public class RequireVBAmount : BaseChallenge
    {
        public bool RequireAmountReached(BaseFlyController BFC, List<GameObject> GOs)
        {
            return BFC.IngestedValues[IngestTypes.VitaminB] >= 100;
        }
        
        [SerializeField]
        private string _name = "VB9 Shortage";
        [SerializeField]
        private string _description = "100 unit of Vitamin B9 will be required for evacuation.";
        [SerializeField]
        private Modifier _difficultyModifier = new Modifier(ModifyOption.Multiplicative, 1.3f, "x");
        
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
            ObjectiveCheck VBRequire = new ObjectiveCheck(RequireAmountReached);
            FindObjectOfType<BaseObjectiveManager>().ObjectiveChecks.Add((_description, VBRequire));
        }
    }
}