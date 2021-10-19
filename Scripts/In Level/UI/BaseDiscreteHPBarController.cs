using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace In_Level.UI
{
    public class BaseDiscreteHPBarController : MonoBehaviour
    {
        public List<Image> blocks;
        public Sprite emptyHpImage;
        public Sprite hasHpImage;

        public float HPProgress = 1;

        private float HPProgressStored = -1;

        public void OrderBlocks()
        {
            if(blocks == null){return;}
            
            blocks = blocks.OrderBy(i => i.rectTransform.anchoredPosition.x).ThenBy(i => i.rectTransform.anchoredPosition.y).ToList();
        }

        protected void Update()
        {
            if (Math.Abs(HPProgressStored - HPProgress) > 0.0001f)
            {
                HPProgressStored = HPProgress;

                if (blocks != null)
                {
                    for (int i = 0; i < blocks.Count; ++i)
                    {
                        if (blocks[i] != null)
                        {
                            blocks[i].sprite = (blocks.Count * HPProgress) > i ? hasHpImage : emptyHpImage;
                        }
                    }
                }
                
            }
        }
        
        
    }
}