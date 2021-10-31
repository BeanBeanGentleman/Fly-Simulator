using System;
using System.Collections.Generic;
using ChallangesModifiers;
using In_Level.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main_Menu
{
    public class ChallangeApplier : MonoBehaviour
    {
        private string TempSceneName;
        public HashSet<BaseChallenge> Challanges;
        public bool Halt = true;

        public float Difficulty;

        public Toggle InverseY;
        private void Update()
        {
            SceneManager.sceneLoaded += ActiveAll;
            DontDestroyOnLoad(this.gameObject);
        }

        private void LateUpdate()
        {
            if(Halt) return;
            Halt = true;
            foreach (var chal in Challanges)
            {
                Type theChal = chal.GetType();
                print(theChal.Name);
                BaseChallenge cha =  (BaseChallenge) this.gameObject.AddComponent(theChal);
                cha.OnLevelLoaded();
            }

            SceneManager.sceneLoaded -= ActiveAll;

            BaseObjectiveManager findObjectOfType = FindObjectOfType<BaseObjectiveManager>();
            if (findObjectOfType)
            {
                findObjectOfType.Difficulty = Difficulty;
                findObjectOfType.DontDestoryOnLoadObjects.Add(this.gameObject);
            }
            
            var BFC = FindObjectOfType<BaseFlyController>();
            if (BFC != null)
            {
                BFC.PitchDirectionMultiplier = InverseY.isOn ? -1 : 1;
            }
        }

        void ActiveAll(Scene a, LoadSceneMode b)
        {
            Halt = false;
        }
    }
}