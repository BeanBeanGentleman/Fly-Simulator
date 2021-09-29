using System;
using Genral;
using UnityEditor;
using UnityEngine;

namespace In_Level.Level_Item_Behaviours.Ingestable
{
    [RequireComponent(typeof(Collider))]
    public class BaseIngestable : MonoBehaviour
    {
        public AutoResetCounter FoodAmount = new AutoResetCounter(10);
        public IngestTypes MyType = IngestTypes.CarboHydrate;

        private void Start()
        {
            FoodAmount.MaxmizeTemp();
        }

        private void OnCollisionStay(Collision other)
        {
            BaseFlyController BFC;
            if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
            {
                if (BFC.Ingesting)
                {
                    float AmountLeft = FoodAmount.Temp;
                    if (FoodAmount.IsZeroReached(BFC.IngestSpeed.FinalVal() * Time.fixedDeltaTime))
                    {
                        ElimateThis();
                    }
                    BFC.IngestIn(MyType,Mathf.Min(AmountLeft, BFC.IngestSpeed.FinalVal() * Time.fixedDeltaTime));
                }
            }
        }
        
        public virtual void ElimateThis()
        {
            Destroy(this.gameObject);
        }
    }
}