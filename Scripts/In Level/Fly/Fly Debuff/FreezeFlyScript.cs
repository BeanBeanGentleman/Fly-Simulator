using System;
using Genral;
using UnityEngine;
using UnityEngine.UI;

namespace In_Level.Fly.Fly_Debuff
{
    public class FreezeFlyScript : BaseDebuff
    {
        public BaseFlyController BFC;
        public float DamagePerSecond;
        public float MobilityDecreasion;
        public float LastingTime;
        public float MobilityLastingTime;
        public Modifier MobilityDecreasionModifier = new Modifier(true, 1, "z");

        private Image IceyImage;

        protected override void Start()
        {
            base.Start();
            BFC = this.gameObject.GetComponent<BaseFlyController>();
            if (BFC == null)
            {
                DestroyImmediate(this);
                Debug.LogError("THIS DEBUFF HAS BEEN APPLIED TO A WRONG GAMEOBJECT!");
            }
            BFC.Agility.SetNoBonusModifier(thisGuid);
            BFC.movementAccel.SetNoBonusModifier(thisGuid);
            IceyImage = GameObject.FindWithTag("OnScreenIce").GetComponent<Image>();
            
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            float TimeLeftFactor = (DebuffTimeLeft.Temp / DebuffTimeLeft.Max);
            BFC.TakeDamage(DamagePerSecond * Time.fixedDeltaTime* TimeLeftFactor);
            MobilityDecreasionModifier.Value = Mathf.Lerp(1, MobilityDecreasion, TimeLeftFactor);
            BFC.Agility.SetModifier(thisGuid, MobilityDecreasionModifier);
            BFC.movementAccel.SetModifier(thisGuid, MobilityDecreasionModifier);
            if (IceyImage != null)
            {
                IceyImage.color = new Color(1, 1, 1, Mathf.Min(IceyImage.color.a + (Time.fixedDeltaTime / 2), TimeLeftFactor));
            }
            else
            {
                print("NUL");
            }
        }

        protected override void OnDestroy()
        {
            BFC.Agility.SetNoBonusModifier(thisGuid);
            BFC.movementAccel.SetNoBonusModifier(thisGuid);
        }
    }
}