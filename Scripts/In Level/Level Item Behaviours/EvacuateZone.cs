using System;
using UnityEngine;
using UnityEngine.UI;

namespace In_Level.Level_Item_Behaviours
{
    public class EvacuateZone : MonoBehaviour
    {
        public bool Evacuatable = false;
        private void OnTriggerStay(Collider other)
        {
            Evacuatable = true;
            BaseFlyController BFC;
            if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
            {
                Evacuatable = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Evacuatable = false;
        }
    }
}