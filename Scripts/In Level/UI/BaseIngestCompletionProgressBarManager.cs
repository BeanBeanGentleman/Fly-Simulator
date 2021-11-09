using System;
using System.Collections.Generic;
using In_Level.Level_Item_Behaviours.Ingestable;
using UnityEngine;
using UnityEngine.UI;

namespace In_Level.UI
{
    public class BaseIngestCompletionProgressBarManager : MonoBehaviour
    {
        public List<Image> Images;
        public Dictionary<IngestTypes, float> IngestedValues;
        public float DevideValue = 1;

        public float TargetValue = 600;

        public Text CompletionValue;

        private IngestTypes[] _converter = new[]
        {
            IngestTypes.Fat,
            IngestTypes.Protein,
            IngestTypes.CarbonHydrate,
            IngestTypes.Water,
            IngestTypes.VitaminA,
            IngestTypes.VitaminB,
            IngestTypes.VitaminC,
            IngestTypes.Mineral,
            IngestTypes.Sodium
        };

        protected virtual void Update()
        {
            CompletionValue.text = $"0/{TargetValue}";
            if (IngestedValues == null) return;
            for (int i = 0; i < Images.Count; ++i)
            {
                IngestTypes theType = _converter[i];
                float TheWidth;
                if (!IngestedValues.TryGetValue(theType, out TheWidth))
                {
                    TheWidth = 0;
                }

                TheWidth *= (600 / TargetValue);
                float Offset = 0;
                if (i != 0)
                {
                    Offset = (Images[i - 1].rectTransform.anchoredPosition.x ) + (Images[i - 1].rectTransform.sizeDelta.x / 2);
                }
                Images[i].rectTransform.anchoredPosition = new Vector3(Offset + ((TheWidth/DevideValue)/2), Images[i].rectTransform.anchoredPosition.y);
                Images[i].rectTransform.sizeDelta = new Vector2((TheWidth / DevideValue), Images[i].rectTransform.sizeDelta.y);
            }
            
            float sum = 0;
            foreach (var vallue in IngestedValues.Values)
            {
                sum += vallue;
            }

            CompletionValue.text = sum.ToString("N1") + $"/{TargetValue}";
        }
    }
}