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

        public FoodCountManager food_manager;
        public BagCountManager bag_count_manager;
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

        private void OnCollisionEnter(Collision collision)
        {
            BaseFlyController BFC;
            Debug.Log("OnCollisionEnter");
            if (collision.gameObject.name == "Fly")
            {
                ElimateThis();
            }
            if (collision.gameObject.name == "Mouse")
            {
                ElimateThisByMouse();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            BaseFlyController BFC;
            if (other.gameObject.name == "Fly")
            {
                ElimateThis();
            }
            /* if (other.gameObject.name == "Mouse")
            {
                ElimateThisByMouse();
            } */ 
        }


        /// <summary>
        /// Call this when the food is depleted
        /// </summary>
        public virtual void ElimateThis()
        {   
            Debug.Log("ElimateThis");
            if (this.gameObject.tag == "Banana")
            {
                bag_count_manager.increase_food_count(2);
            }
            else if (this.gameObject.tag == "Cheese")
            {
                bag_count_manager.increase_food_count(0);
            }
            else
            {
                bag_count_manager.increase_food_count(1);
            }
            Destroy(this.gameObject);
        }

        public virtual void ElimateThisByMouse()
        {
            Debug.Log("ElimateThis");
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