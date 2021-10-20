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
        private float BaseResourceMaxAmount = 0.5f;
        /// <summary>
        /// The value container of the resource max amount.  
        /// </summary>
        public ValueContainer ResourceMaxAmount;

        public FoodCountManager food_manager;

        public GameObject ParentGameObject;

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

        protected virtual void OnCollisionEnter(Collision other)
        {
            BaseFlyController BFC;
            if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
            {
                if (BFC.Ingesting)
                {
                    float AmountLeft = FoodAmount.Temp;
                    ElimateThis();
                    BFC.IngestIn(MyType,Mathf.Min(AmountLeft, BFC.IngestSpeed.FinalVal() * Time.fixedDeltaTime));
                }
            }
        }
        /// <summary>
        /// Call this when the food is depleted
        /// </summary>
        public virtual void ElimateThis()
        {
            if (this.gameObject.tag == "Banana")
            {
                food_manager.decrease_food_count(2, 1);
            }
            else if (this.gameObject.tag == "Cheese")
            {
                food_manager.decrease_food_count(0, 1);
            }
            else
            {
                food_manager.decrease_food_count(1, 1);
            }
            Destroy(this.gameObject);
        }

        public virtual void RemoveParent()
        {
            DestroyImmediate(this.gameObject);
        }

        public virtual void UpdateMaxAmount(Guid guid, Modifier modify)
        {
            ResourceMaxAmount.SetModifier(guid, modify);
            FoodAmount.Max = ResourceMaxAmount.FinalVal();
            FoodAmount.MaxmizeTemp();
        }
    }
}