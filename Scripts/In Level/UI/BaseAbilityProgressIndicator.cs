using System;
using UnityEngine;
using UnityEngine.UI;

namespace In_Level.UI
{
    public class BaseAbilityProgressIndicator : MonoBehaviour
    {
        public float progress = 1;
        public float CDProgress = 1;
        public bool showNoProgress = false;
        public bool activating = false;

        public Image filler;
        public Color runningColor = Color.green;
        public Color CDColor = Color.red;
        public Color idleColor = Color.white;

        protected virtual void Start()
        {
            if (filler == null)
            {
                Debug.LogError("THE FILLER IMAGE IS MISSING!");
                Destroy(this);
            }
        }

        protected virtual void Update()
        {
            float ToBeFillAmount = 0;
            if (activating)
            {
                ToBeFillAmount = showNoProgress?1:progress;
                filler.color = runningColor;
            }
            else
            {
                CDProgress = Mathf.Clamp01(CDProgress);
                ToBeFillAmount = 1-CDProgress;
                filler.color = Color.Lerp(idleColor, CDColor , Mathf.Clamp01((CDProgress - 0.1f) * 20));    
            }

            filler.fillAmount = Mathf.Lerp(filler.fillAmount, ToBeFillAmount, 0.5f);
        }

        private void OnTriggerStay(Collider other)
        {
            Vector3 direction = other.transform.forward;
            Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();

            rb.useGravity = false;
            rb.AddForce(direction * 10);
            rb.velocity = rb.velocity * 0.8f;
            rb.velocity += Physics.gravity * 0.3f;
        }
    }
}