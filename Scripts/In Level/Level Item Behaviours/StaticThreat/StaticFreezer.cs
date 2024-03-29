﻿using System;
using Genral;
using In_Level.Fly.Fly_Debuff;
using UnityEngine;

namespace In_Level.Level_Item_Behaviours.StaticThreat
{
    public class StaticFreezer : StaticDamageZone
    {
        public AnimationCurve MobilityReductionOverTimeMultiplier = new AnimationCurve();

        public float MobilityReductionStackSpeedMultiplierBaseVal = 1;
        [HideInInspector]
        public ValueContainer MobilityReductionStackSpeedMultiplier;
        
        public float MobilityReductionBaseValPerSecVal = 1;
        [HideInInspector]
        public ValueContainer MobilityReductionBaseValPerSec;

        protected override void Start()
        {
            base.Start();
            MobilityReductionStackSpeedMultiplier = new ValueContainer(MobilityReductionStackSpeedMultiplierBaseVal);
            MobilityReductionBaseValPerSec = new ValueContainer(MobilityReductionBaseValPerSecVal);
        }

        protected override void OnTriggerStay(Collider other)
        {
            BaseFlyController incoming;
            if(other.TryGetComponent(out incoming))
            {
                FreezeFlyScript ffs;
                if (!other.TryGetComponent(out ffs))
                {
                    ffs = incoming.gameObject.AddComponent<FreezeFlyScript>();
                }
                ffs.DebuffTimeLeft.MaxmizeTemp();
                ffs.LastingTime += Time.fixedDeltaTime * DamageStackSpeedMultiplier.FinalVal();
                ffs.MobilityLastingTime += Time.fixedDeltaTime * MobilityReductionStackSpeedMultiplier.FinalVal();
                ffs.DamagePerSecond = DamageOverTimeMultiplier.Evaluate(ffs.LastingTime) * DamageBaseValPerSec.FinalVal();
                ffs.MobilityDecreasion = MobilityReductionOverTimeMultiplier.Evaluate(ffs.LastingTime) * MobilityReductionBaseValPerSec.FinalVal();
            }
        }

        protected override void OnTriggerExit(Collider other)
        {
            BaseFlyController incoming;
            if(other.TryGetComponent(out incoming))
            {
                FreezeFlyScript ffs;
                if (!other.TryGetComponent(out ffs))
                {
                    return;
                }
                ffs.DamagePerSecond = ffs.DamagePerSecond * 0.5f;
                ffs.MobilityDecreasion = ffs.MobilityDecreasion * 0.5f;
            }
        }
    }
}