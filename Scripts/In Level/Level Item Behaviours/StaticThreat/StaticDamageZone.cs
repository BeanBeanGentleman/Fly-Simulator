using System;
using System.Collections.Generic;
using Genral;
using In_Level.Fly.Fly_Debuff;
using UnityEngine;

namespace In_Level.Level_Item_Behaviours.StaticThreat
{
    public class StaticDamageZone : MonoBehaviour
    {
        public AnimationCurve DamageOverTimeMultiplier = new AnimationCurve();


        public float DamageStackSpeedMultiplierBaseVal = 1;
        [HideInInspector]
        public ValueContainer DamageStackSpeedMultiplier;
        
        public float DamageBaseValPerSecVal = 1;
        [HideInInspector]
        public ValueContainer DamageBaseValPerSec;

        protected virtual void Start()
        {
            DamageStackSpeedMultiplier = new ValueContainer(DamageStackSpeedMultiplierBaseVal);
            DamageBaseValPerSec = new ValueContainer(DamageBaseValPerSecVal);
        }

        protected void FixedUpdate()
        {

        }

        protected virtual void OnTriggerStay(Collider other)
        {
            BaseFlyController incoming;
            if(other.TryGetComponent(out incoming))
            {
                DamageOverTimeScript ffs;
                if (!other.TryGetComponent(out ffs))
                {
                    ffs = incoming.gameObject.AddComponent<DamageOverTimeScript>();
                }
                ffs.DebuffTimeLeft.MaxmizeTemp();
                ffs.LastingTime += Time.fixedDeltaTime * DamageStackSpeedMultiplier.FinalVal();
                ffs.DamagePerSecond = DamageOverTimeMultiplier.Evaluate(ffs.LastingTime) * DamageBaseValPerSec.FinalVal();
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            BaseFlyController incoming;
            if(other.TryGetComponent(out incoming))
            {
                DamageOverTimeScript ffs;
                if (!other.TryGetComponent(out ffs))
                {
                    return;
                }
                ffs.DamagePerSecond = ffs.DamagePerSecond * 0.3f;
            }
        }
    }
}