using System;
using Genral;
using UnityEditor;
using UnityEngine;

namespace In_Level.Level_Item_Behaviours.Ingestable
{
    [RequireComponent(typeof(Collider))]
    public class BaseIngestable : MonoBehaviour
    {
        /// <summary>
        /// The base resource max amount.
        /// </summary>
        public float BaseResourceMaxAmount = 10f;
        /// <summary>
        /// The value container of the resource max amount.  
        /// </summary>
        public ValueContainer ResourceMaxAmount;
        /// <summary>
        /// The amount left in this ingestable resource.
        /// </summary>
        public AutoResetCounter FoodAmount;
        /// <summary>
        /// The type of food
        /// </summary>
        public IngestTypes MyType = IngestTypes.CarbonHydrate;
        /// <summary>
        /// The very parent. Used for removal under challenges.
        /// </summary>
        public GameObject ParentGameObject;
        /// <summary>
        /// The rating of how this ingestable resource is exposed and easy to acquire. 
        /// </summary>
        public int ExposureLevel;

        protected virtual void Start()
        {
            ResourceMaxAmount = new ValueContainer(BaseResourceMaxAmount);
            FoodAmount = new AutoResetCounter(ResourceMaxAmount.FinalVal());
            FoodAmount.MaxmizeTemp();
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
        /// <summary>
        /// Call this when the food is depleted
        /// </summary>
        public virtual void ElimateThis()
        {
            Destroy(this.gameObject);
        }

        public virtual void RemoveParent()
        {
            if (this.ParentGameObject != null)
            {
                DestroyImmediate(this.ParentGameObject);
            }
            else
            {
                DestroyImmediate(this.gameObject);
            }
        }

        public virtual void UpdateMaxAmount(Guid guid, Modifier modify)
        {
            ResourceMaxAmount.SetModifier(guid, modify);
            FoodAmount.Max = ResourceMaxAmount.FinalVal();
            FoodAmount.MaxmizeTemp();
        }
    }
}