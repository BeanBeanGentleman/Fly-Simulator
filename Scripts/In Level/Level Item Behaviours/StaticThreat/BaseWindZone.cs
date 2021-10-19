using System;
using Genral;
using UnityEngine;

namespace In_Level.Level_Item_Behaviours.StaticThreat
{
    public class BaseWindZone : MonoBehaviour
    {
        public float BaseWindStrength = 1;
        [HideInInspector]
        public ValueContainer WindStrength;
        public AnimationCurve WindStrengthOverDistance;

        protected virtual void Start()
        {
            WindStrength = new ValueContainer(BaseWindStrength);
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                other.attachedRigidbody.AddForce(WindStrength.FinalVal() * WindStrengthOverDistance.Evaluate((other.transform.position - this.transform.position)
                .magnitude) * this.transform.forward);
            }
        }
    }
}