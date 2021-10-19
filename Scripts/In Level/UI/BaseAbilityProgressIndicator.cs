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
            if (activating)
            {
                filler.fillAmount = showNoProgress?1:progress;
                filler.color = runningColor;
            }
            else
            {
                CDProgress = Mathf.Clamp01(CDProgress);
                filler.fillAmount = CDProgress;
                filler.color = Color.Lerp(CDColor, idleColor, Mathf.Clamp01((CDProgress - 0.95f) * 20));    
            }
        }
    }
}