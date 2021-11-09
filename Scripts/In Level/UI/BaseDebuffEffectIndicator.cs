using System;
using UnityEngine;
using UnityEngine.UI;

namespace In_Level.UI
{
    public class BaseDebuffEffectIndicator : MonoBehaviour
    {
        /// <summary>
        /// Modify this for the size growth for
        /// </summary>
        public float progress = 0;

        private Vector2 _defaultScaleDelta;

        public Image TargetImage;

        protected virtual void Start()
        {
            if (TargetImage == null)
            {
                Debug.LogError("THE TARGET IMAGE IS MISSING!");
                Destroy(this);
            }

            _defaultScaleDelta = TargetImage.rectTransform.sizeDelta;
        }

        protected virtual void Update()
        {
            TargetImage.rectTransform.sizeDelta = _defaultScaleDelta * (1 + progress);
        }
    }
}