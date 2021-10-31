using System;
using System.Collections.Generic;
using System.Text;
using ChallangesModifiers;
using Genral;
using UnityEngine;
using UnityEngine.UI;

namespace Main_Menu
{
    public class DemoPhlySelector : MonoBehaviour
    {
        public GameObject ToggleParent;
        public PhlyApplier PhlyApplier;

        private void Start()
        {
            if (ToggleParent == null)
            {
                Debug.LogError("TOGGLE PARENT IS MISSING!");
                Destroy(this);
            }
        }

        private void Update()
        {
            foreach (var toggle in ToggleParent.GetComponentsInChildren<Toggle>())
            {
                if (toggle.isOn)
                {
                    if(toggle.gameObject.name == "UseNormalFly"){
                        PhlyApplier.ChoosePhlyType(PhlyTypes.Normal);
                    }
                    if(toggle.gameObject.name == "UseEvolvedFly"){
                        PhlyApplier.ChoosePhlyType(PhlyTypes.Evolved);
                    }
                    if(toggle.gameObject.name == "UseMetalFly"){
                        PhlyApplier.ChoosePhlyType(PhlyTypes.Metal);
                    }
                }
            }
        }
    }
}