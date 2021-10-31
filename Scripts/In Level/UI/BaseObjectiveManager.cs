using System;
using System.Collections.Generic;
using System.Text;
using In_Level.Level_Item_Behaviours;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace In_Level.UI
{
    public delegate bool ObjectiveCheck(BaseFlyController BFC, List<GameObject> CheckList);
    public class BaseObjectiveManager : MonoBehaviour, FlyAbilityControl.ISurviabilityAbilityActions
    {
        public Text Objectives;
        public Text Difficulties;
        public Text GameOver;
        public BaseFlyController BFC;

        public Animator ObjectiveAnimator;

        public Animator GameOverAnimator;

        public Animator GameClearAnimator;

        public List<GameObject> DontDestoryOnLoadObjects = new List<GameObject>();

        public List<GameObject> CheckList = new List<GameObject>();

        public List<(String, ObjectiveCheck)> ObjectiveChecks = new List<(string, ObjectiveCheck)>();

        public bool AllAchieved = false;

        public float Difficulty = 1;
        
        public string ReturnName = "Main Menu";

        public bool Died = false;
        private void Update()
        {
            if (BFC == null && !AllAchieved)
            {
                BFC = FindObjectOfType<BaseFlyController>();
                if (BFC == null)
                {
                    Debug.LogError("Base Fly Controller cannot be located!");
                    return;
                }
            }

            foreach (GameObject goo in CheckList)
            {
                if (goo == null)
                {
                    // TODO: Remove that
                }
            }

            StringBuilder StrB = new StringBuilder();
            Objectives.text = "";
            AllAchieved = ObjectiveChecks.Count != 0;
            if (BFC != null)
            {
                foreach ((String, ObjectiveCheck) cheque in ObjectiveChecks)
                {
                    bool Achieved = cheque.Item2(BFC, CheckList);
                    StrB.Append((Achieved ? "〇" : "X") + $" {cheque.Item1}\n");
                    AllAchieved = AllAchieved && Achieved;
                } 
            }


            Difficulties.text = $"Difficulty Cleared: {Difficulty}\nPress B to Main Menu";
            Objectives.text = StrB.ToString();
            
            if (BFC && BFC.GetHP() <= 0 )
            {
                GameOverAnimator.SetBool("GameOver", true);
                Died = true;
                Destroy(BFC);
            }
            else if (AllAchieved)
            {
                GameClearAnimator.SetBool("GameClear", true);
                ObjectiveAnimator.SetBool("GameClear", true);
                // Time.timeScale *= 0.98f;
                Destroy(BFC);
            }
            else
            {
                GameClearAnimator.SetBool("GameClear", false);
                ObjectiveAnimator.SetBool("GameClear", false);
                // Time.timeScale = 1;
            }
        }
        
        private FlyAbilityControl _FlyInputActions;
        public void Awake()
        {
            _FlyInputActions = new FlyAbilityControl();
            _FlyInputActions.SurviabilityAbility.SetCallbacks(this);
        }
    
        public void OnEnable()
        {
            _FlyInputActions.SurviabilityAbility.Enable();
        }

        public void OnDisable()
        {
            _FlyInputActions.SurviabilityAbility.Disable();
        }
        public void OnUse(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started && (AllAchieved || Died))
            {
                foreach (GameObject go in DontDestoryOnLoadObjects)
                {
                    if(go != null) DestroyImmediate(go);
                }
                SceneManager.LoadScene(ReturnName);
            }
        }
    }
}