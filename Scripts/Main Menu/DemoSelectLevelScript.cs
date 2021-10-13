using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main_Menu
{
    public class DemoSelectLevelScript : MonoBehaviour
    {
        public Image WIP;
        public Image pnl;
        public Image Me;
        public Rect TargetRectMe;
        public Rect TargetRectWIP;
        public Rect TargetRectpnl;
        private int ClickCount = 0;
        public void ClickMe(string sceneName)
        {
            if (ClickCount == 0)
            {
                
            }

            if (ClickCount == 1)
            {
                SceneManager.LoadScene(sceneName);
                GameObject.FindObjectOfType<bgmStuff>().Switch();
            }

            ClickCount += 1;
        }

        private void Update()
        {
            
            if (ClickCount == 1)
            {
                var f = 0.02f;
                WIP.rectTransform.position = Vector3.Lerp(WIP.rectTransform.position, TargetRectWIP.position, f);
                WIP.rectTransform.sizeDelta = Vector3.Lerp(WIP.rectTransform.sizeDelta, TargetRectWIP.size, f);
                pnl.rectTransform.position = Vector3.Lerp(pnl.rectTransform.position, TargetRectpnl.position, f);
                pnl.rectTransform.sizeDelta = Vector3.Lerp(pnl.rectTransform.sizeDelta, TargetRectpnl.size, f);
                Me.rectTransform.position = Vector3.Lerp(Me.rectTransform.position, TargetRectMe.position, f);
                Me.rectTransform.sizeDelta = Vector3.Lerp(Me.rectTransform.sizeDelta, TargetRectMe.size, f);
            }
        }
    }
}