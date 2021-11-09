using System;
using ChallangesModifiers;
using In_Level.Fly.Fly_Abilities;
using In_Level.Fly.Fly_Passive_Abilities;
using In_Level.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main_Menu
{
    public class PhlyApplier : MonoBehaviour
    {
        private PhlyTypes SelectedPhlyType;
        private string TempSceneName;
        
        
        public bool Halt = true;
        
        
        private void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public void ChoosePhlyType(PhlyTypes type)
        {
            SelectedPhlyType = type;
        }

        private void Update()
        {
            SceneManager.sceneLoaded += ActiveAll;
            DontDestroyOnLoad(this.gameObject);
        }

        private void LateUpdate()
        {
            if(Halt) return;
            Halt = true;

            SceneManager.sceneLoaded -= ActiveAll;

            BaseObjectiveManager BOM = FindObjectOfType<BaseObjectiveManager>();
            if (BOM)
            {
                BOM.DontDestoryOnLoadObjects.Add(this.gameObject);
            }
            
            var BFC = FindObjectOfType<BaseFlyController>();
            if (BFC != null)
            {
                if (SelectedPhlyType == PhlyTypes.Normal)
                {
                    if(BFC.gameObject.GetComponent<RecoveryBuff>()) BFC.gameObject.GetComponent<RecoveryBuff>().EnableThisPassiveAbility();
                    if(BFC.gameObject.GetComponent<AfterBurnerBuff>()) BFC.gameObject.GetComponent<AfterBurnerBuff>().EnableThisAbility();
                    if(BFC.gameObject.GetComponent<CovertOpsBuff>()) BFC.gameObject.GetComponent<CovertOpsBuff>().EnableThisAbility();
                    if(BFC.gameObject.GetComponent<GluttonyBuff>()) BFC.gameObject.GetComponent<GluttonyBuff>().EnableThisAbility();
                }
                if (SelectedPhlyType == PhlyTypes.Evolved)
                {
                    if(BFC.gameObject.GetComponent<NATBBuff>()) BFC.gameObject.GetComponent<NATBBuff>().EnableThisPassiveAbility();
                    if(BFC.gameObject.GetComponent<FuelInjectorBuff>()) BFC.gameObject.GetComponent<FuelInjectorBuff>().EnableThisAbility();
                    if(BFC.gameObject.GetComponent<OversensingBuff>()) BFC.gameObject.GetComponent<OversensingBuff>().EnableThisAbility();
                    if(BFC.gameObject.GetComponent<ExuviateBuff>()) BFC.gameObject.GetComponent<ExuviateBuff>().EnableThisAbility();
                }
                if (SelectedPhlyType == PhlyTypes.Metal)
                {
                    // if(BFC.gameObject.GetComponent<>())BFC.gameObject.GetComponent<>()
                    if(BFC.gameObject.GetComponent<MicroJumpDriveBuff>()) BFC.gameObject.GetComponent<MicroJumpDriveBuff>().EnableThisAbility();
                    if(BFC.gameObject.GetComponent<HologramDecoyProjectionBuff>()) BFC.gameObject.GetComponent<HologramDecoyProjectionBuff>()
                    .EnableThisAbility();
                    if(BFC.gameObject.GetComponent<MiniRocketsBuff>()) BFC.gameObject.GetComponent<MiniRocketsBuff>().EnableThisAbility();
                }
                
            }
        }

        void ActiveAll(Scene a, LoadSceneMode b)
        {
            Halt = false;
        }
    }

    public enum PhlyTypes
    {
        Normal,
        Evolved,
        Metal,
    }
}