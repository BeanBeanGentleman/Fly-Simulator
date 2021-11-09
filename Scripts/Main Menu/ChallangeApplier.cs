using System;
using System.Collections.Generic;
using ChallangesModifiers;
<<<<<<< HEAD
using UnityEngine;
using UnityEngine.SceneManagement;
=======
using In_Level.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
>>>>>>> dev_tony

namespace Main_Menu
{
    public class ChallangeApplier : MonoBehaviour
    {
        private string TempSceneName;
        public HashSet<BaseChallenge> Challanges;
        public bool Halt = true;

        public float Difficulty;

<<<<<<< HEAD
=======
        public Toggle InverseY;
>>>>>>> dev_tony
        private void Update()
        {
            SceneManager.sceneLoaded += ActiveAll;
            DontDestroyOnLoad(this.gameObject);
        }

        private void LateUpdate()
        {
            if(Halt) return;
            Halt = true;
<<<<<<< HEAD
            foreach (var chal in Challanges)
            {
                Type theChal = chal.GetType();
                print(theChal.Name);
                BaseChallenge cha =  (BaseChallenge) this.gameObject.AddComponent(theChal);
                cha.OnLevelLoaded();
            }

            SceneManager.sceneLoaded -= ActiveAll;
=======
            
            var BFC = FindObjectOfType<BaseFlyController>();
            if (BFC != null)
            {
                BFC.PitchDirectionMultiplier = InverseY.isOn ? -1 : 1;
            }
            
            if (Challanges != null)
            {
                foreach (var chal in Challanges)
                {
                    Type theChal = chal.GetType();
                    print(theChal.Name);
                    BaseChallenge cha =  (BaseChallenge) this.gameObject.AddComponent(theChal);
                    cha.OnLevelLoaded();
                }
            }

            SceneManager.sceneLoaded -= ActiveAll;

            BaseObjectiveManager findObjectOfType = FindObjectOfType<BaseObjectiveManager>();
            if (findObjectOfType)
            {
                findObjectOfType.Difficulty = Difficulty;
                findObjectOfType.DontDestoryOnLoadObjects.Add(this.gameObject);
            }
            

>>>>>>> dev_tony
        }

        void ActiveAll(Scene a, LoadSceneMode b)
        {
            Halt = false;
        }
    }
}