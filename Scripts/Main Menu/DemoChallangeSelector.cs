using System;
using System.Collections.Generic;
using System.Text;
using ChallangesModifiers;
using Genral;
<<<<<<< HEAD
=======
using In_Level.UI;
>>>>>>> dev_tony
using UnityEngine;
using UnityEngine.UI;

namespace Main_Menu
{
    public class DemoChallangeSelector : MonoBehaviour
    {
        public Text DetailText;
        public GameObject ToggleParents;
        public HashSet<BaseChallenge> BCs = new HashSet<BaseChallenge>();
        

<<<<<<< HEAD
        public ValueContainer Difficulty = new ValueContainer(1);
=======
        public ValueContainer Difficulty = new ValueContainer(0);
>>>>>>> dev_tony

        public ChallangeApplier TargetChallangeApplier;

        private void Start()
        {
            DetailText = DetailText == null ? this.gameObject.GetComponent<Text>():DetailText;
            if (DetailText == null)
            {
                Debug.LogError("DETAILED TEXT IS MISSING!");
                Destroy(this);
            }
            if (ToggleParents == null)
            {
                Debug.LogError("TOGGLE PARENT IS MISSING!");
                Destroy(this);
            }
        }

        private void Update()
        {
            Difficulty.ClearModifiers();
            StringBuilder TempText = new StringBuilder();
<<<<<<< HEAD
=======
            BCs.Clear();
            TempText.Append("Click the level banner above to enter the game. \n\nSelect your challenges from left. \n\n");
>>>>>>> dev_tony
            foreach (Toggle singleToggle in ToggleParents.GetComponentsInChildren<Toggle>())
            {
                if (singleToggle.isOn)
                {
                    BaseChallenge bc;
                    if (singleToggle.gameObject.TryGetComponent(out bc))
                    {
                        BCs.Add(bc);
                        TempText.Append(bc.DifficultyModifier.IsMultiply?"×":"+");
                        TempText.Append(bc.DifficultyModifier.Value.ToString("N2"));
                        TempText.Append("  ");
                        TempText.Append(bc.Description);
                        TempText.Append("\n\n");
                        
                        Difficulty.SetModifier(Guid.NewGuid(), bc.DifficultyModifier);
                    }
                }
            }

            TempText.AppendFormat("Total Difficulty: {0}", Difficulty.FinalVal());
            DetailText.text = TempText.ToString();
            TargetChallangeApplier.Challanges = BCs;
            TargetChallangeApplier.Difficulty = Difficulty.FinalVal();
<<<<<<< HEAD
=======


>>>>>>> dev_tony
        }
    }
}