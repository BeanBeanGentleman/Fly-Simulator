﻿using UnityEngine;

namespace In_Level.Level_Item_Behaviours.Trap
{
    public class LoseHPWebifier : BaseWebifier
    {
        public AutoResetCounter HP = new AutoResetCounter(10);
        public HealthBar hp_bar;
        public HealthBarScr escape_progressbar;
        public bool playerOnWeb = false;
        protected override void Start()
        {
            base.Start();
            HP.MaxmizeTemp();
        }

        private void OnTriggerEnter(Collider other)
        {
            BaseFlyController BFC;
            if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
            {
                // Instantiate Escape Progress Bar here
            }
        }

        protected override void OnTriggerStay(Collider other)
        {
            BaseFlyController BFC;
            if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
            {
                playerOnWeb = true;
                BFC.AirDragVal.SetModifier(thisGuid, Webifier);

            }
        }

        protected override void OnTriggerExit(Collider other)
        {
            BaseFlyController BFC;
            if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
            {
                playerOnWeb = false;
                BFC.AirDragVal.SetNoBonusModifier(thisGuid); 
            }
        }

        private void Update()
        {
            if (!playerOnWeb)
            {
                return;
            }
            else
            {
                float cur_hp = hp_bar.getValue();
                cur_hp += -0.01f;
                hp_bar.setValue(cur_hp);


                if (escape_progressbar.cur_p() >= 92f)
                {
                    Destroy(this.gameObject);
                }

            }
        }
    }
}