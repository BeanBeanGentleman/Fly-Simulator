using System;
using Genral;
using UnityEngine;

namespace In_Level.Fly.Fly_Passive_Abilities
{
    public class NATBBuff : BasePassiveAbility
    {
        public float BaseBonusMultiplier = 2;
        public ValueContainer FinalBonusMultiplier;

        private float _stackProgressMove = 0;
        private float _stackProgressIngest = 0;

        private Guid thisGuid;
        protected override void Active()
        {
            if (FinalBonusMultiplier == null)
            {
                FinalBonusMultiplier = new ValueContainer(BaseBonusMultiplier);
                thisGuid = Guid.NewGuid();
            }

            Modifier mdfM = new Modifier(ModifyOption.Multiplicative, Mathf.Lerp(1, FinalBonusMultiplier.FinalVal(), _stackProgressMove), "y");
            Modifier mdfI = new Modifier(ModifyOption.Multiplicative, Mathf.Lerp(1, FinalBonusMultiplier.FinalVal(), _stackProgressIngest), "y");

            if (_foreBack != 0 || _leftRight != 0 || _climbForeBack != 0 || _climbLeftRight != 0)
            {
                thisFlyController.movementAccel.SetModifier(thisGuid, mdfM);
                thisFlyController.IngestSpeed.SetNoBonusModifier(thisGuid);
                _stackProgressIngest = 0;
                _stackProgressMove += Time.deltaTime / 5;
                _stackProgressMove = Mathf.Clamp01(_stackProgressMove);
            }
            if (_ingest)
            {
                thisFlyController.IngestSpeed.SetModifier(thisGuid, mdfI);
                thisFlyController.movementAccel.SetNoBonusModifier(thisGuid);
                _stackProgressMove = 0;
                _stackProgressIngest += Time.deltaTime / 5;
                _stackProgressIngest = Mathf.Clamp01(_stackProgressIngest);
            }
        }
    }
}