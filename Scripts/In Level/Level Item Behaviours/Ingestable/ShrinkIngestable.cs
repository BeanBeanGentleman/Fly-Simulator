using UnityEngine;

namespace In_Level.Level_Item_Behaviours.Ingestable
{
    public class ShrinkIngestable : BaseIngestable
    {
        private Vector3 StartScale;
        public Vector3 EndScaleCompareToCurrent;
        protected override void Start()
        {
            base.Start();
            StartScale = this.transform.localScale;
        }

        protected virtual void FixedUpdate()
        {
            this.transform.localScale = Vector3.Lerp(StartScale, 
                new Vector3(StartScale.x * EndScaleCompareToCurrent.x,
                    StartScale.y * EndScaleCompareToCurrent.y,
                    StartScale.z * EndScaleCompareToCurrent.z
                    ),
                    1 - (FoodAmount.Temp / FoodAmount.Max)
                );
        }
        protected virtual void OnCollisionStay(Collision other)
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

        public override void ElimateThis()
        {
            Destroy(this);
        }
    }
}