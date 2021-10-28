using System.Collections.Generic;
using Genral;
using In_Level.Level_Item_Behaviours;
using In_Level.Level_Item_Behaviours.Ingestable;
using In_Level.UI;
using UnityEngine;

namespace ChallangesModifiers.Objective_Challenges
{
    public class EvacuateFromEvacuateZone : BaseChallenge
    {
        public bool EZReached(BaseFlyController BFC, List<GameObject> GOs)
        {
            EvacuateZone EZ = null; //TODO
            foreach (GameObject GO in GOs)
            {
                if (GO.TryGetComponent(out EZ))
                {
                    break;
                }
            }

            if (EZ == null)
            {
                return false;
            }

            return EZ.Evacuatable;
        }
        
        [SerializeField]
        private string _name = "Evacuate";
        [SerializeField]
        private string _description = "Evacuate.";
        [SerializeField]
        private Modifier _difficultyModifier = new Modifier(ModifyOption.Additive, 0.5f, "a");
        
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
            ObjectiveCheck Evacuatable = new ObjectiveCheck(EZReached);
            FindObjectOfType<BaseObjectiveManager>().ObjectiveChecks.Add((_description, Evacuatable));
            FindObjectOfType<BaseObjectiveManager>().CheckList.Add(FindObjectOfType<EvacuateZone>().gameObject);
        }
    }
}