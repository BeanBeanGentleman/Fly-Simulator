using UnityEngine;
using UnityEngine.UI;

namespace In_Level.Level_Item_Behaviours.Trap
{
    public class LoseHPWebifier : BaseWebifier
    {
        public AutoResetCounter HP = new AutoResetCounter(10);
        public HealthBar hp_bar;
        public HealthBarScr escape_progressbar;
        public GameObject popup;
        public bool playerOnWeb = false;
        BaseFlyController BFC;
        protected override void Start()
        {
            base.Start();
            HP.MaxmizeTemp();
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
            {
                // Instantiate Escape Progress Bar here
                escape_progressbar.gameObject.SetActive(true);
                popup.SetActive(true);
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

        void restore_speed()
        {
            playerOnWeb = false;
            BFC.AirDragVal.SetNoBonusModifier(thisGuid); 
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
                cur_hp += -0.001f;
                hp_bar.setValue(cur_hp);


                if (escape_progressbar.cur_p() >= 95f)
                {
                    Destroy(this.gameObject);
                    restore_speed();
                    escape_progressbar.gameObject.SetActive(false);
                    popup.SetActive(false);
                }

            }
        }
    }
}