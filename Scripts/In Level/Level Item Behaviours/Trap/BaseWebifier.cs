using System;
using Genral;
using UnityEditor;
using UnityEngine;

namespace In_Level.Level_Item_Behaviours.Trap
{
    public class BaseWebifier : MonoBehaviour
    {
        /// <summary>
        /// The webifier modifier. This will be used for adding drag to the fly.
        /// </summary>
        public Modifier Webifier = new Modifier(false, 1000f, "a");
        public Guid thisGuid;

        protected virtual void Start()
        {
            thisGuid = Guid.NewGuid();
        }

        protected virtual void OnCollisionStay(Collision other)
        {
            OnTriggerStay(other.collider);
        }
        protected virtual void OnCollisionExit(Collision other)
        {
            OnTriggerExit(other.collider);
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            BaseFlyController BFC;
            if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
            {
                BFC.AirDragVal.SetModifier(thisGuid, Webifier);   
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            BaseFlyController BFC;
            if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
            {
                BFC.AirDragVal.SetNoBonusModifier(thisGuid); 
            }
        }
    }
}