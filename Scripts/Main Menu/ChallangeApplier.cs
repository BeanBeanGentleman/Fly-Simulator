using System;
using System.Collections.Generic;
using ChallangesModifiers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main_Menu
{
    public class ChallangeApplier : MonoBehaviour
    {
        private string TempSceneName;
        public HashSet<BaseChallenge> Challanges;
        public bool Halt = true;

        public float Difficulty;

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
        }

        void ActiveAll(Scene a, LoadSceneMode b)
        {
            Halt = false;
        }
    }
}