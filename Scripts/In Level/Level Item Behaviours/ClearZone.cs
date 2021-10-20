using System;
using UnityEngine;
using UnityEngine.UI;

namespace In_Level.Level_Item_Behaviours
{
    public class ClearZone : MonoBehaviour
    {
        public Image Clear;
        public Image NotClear;

        private void OnTriggerStay(Collider other)
        {
            BaseFlyController BFC;
            if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
            {
                float sum = 0;
                foreach (var vallue in BFC.IngestedValues.Values)
                {
                    sum += vallue;
                }

                if (sum >= 600)
                {
                    Clear.gameObject.SetActive(true);
                    Time.timeScale *= 0.8f;
                }
                else
                {
                    NotClear.gameObject.SetActive(true);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            NotClear.gameObject.SetActive(false);
        }
    }
}