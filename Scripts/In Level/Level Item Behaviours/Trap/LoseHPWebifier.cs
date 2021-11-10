using UnityEngine;

namespace In_Level.Level_Item_Behaviours.Trap
{
    public class LoseHPWebifier : BaseWebifier
    {
        public AutoResetCounter HP = new AutoResetCounter(10);
        public bool playerOnWeb = false;
        protected override void Start()
        {
            base.Start();
            HP.MaxmizeTemp();
        }

        protected override void OnTriggerStay(Collider other)
        {
            BaseFlyController BFC;
            if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
            {
                playerOnWeb = true;
                if (HP.IsZeroReached(Time.fixedDeltaTime, false))
                {
                    playerOnWeb = false;
                    BFC.AirDragVal.SetNoBonusModifier(thisGuid);
                    Destroy(this.gameObject);
                }
                else
                {
                    BFC.AirDragVal.SetModifier(thisGuid, Webifier);
                }
                
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
    }
}