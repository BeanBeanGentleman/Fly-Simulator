using System;
using System.Collections.Generic;
using ChallangesModifiers;
using UnityEngine;
<<<<<<< HEAD
=======
using UnityEngine.InputSystem;
>>>>>>> dev_tony
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

        public List<BaseChallenge> Challenges;

        public Animator CanvasAnimator;
        private static readonly int UseApart = Animator.StringToHash("Use Apart");

        public void ClickMe(string sceneName)
        {
            if (ClickCount == 0)
            {
                CanvasAnimator.SetBool(UseApart, true);
                // int count = 0;
                // foreach (var cha in Challenges)
                // {
                //     var chaToggle = GameObject.Instantiate(cha.PrefabToggle.gameObject);
                //     // chaToggle.
                //     chaToggle.transform.parent = pnl.transform;
                //     chaToggle.transform.position = new Vector3(-641, 315 - 85 * count, 0);
                //     count++;
                // }
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
<<<<<<< HEAD
            
=======
>>>>>>> dev_tony
            if (ClickCount == 1)
            {
                // var f = 0.02f;
                // WIP.rectTransform.position = Vector3.Lerp(WIP.rectTransform.position, TargetRectWIP.position, f);
                // WIP.rectTransform.sizeDelta = Vector3.Lerp(WIP.rectTransform.sizeDelta, TargetRectWIP.size, f);
                // pnl.rectTransform.position = Vector3.Lerp(pnl.rectTransform.position, TargetRectpnl.position, f);
                // pnl.rectTransform.sizeDelta = Vector3.Lerp(pnl.rectTransform.sizeDelta, TargetRectpnl.size, f);
                // Me.rectTransform.position = Vector3.Lerp(Me.rectTransform.position, TargetRectMe.position, f);
                // Me.rectTransform.sizeDelta = Vector3.Lerp(Me.rectTransform.sizeDelta, TargetRectMe.size, f);
            }
        }

        void ReturnToMainMenu()
        {
            ClickCount = 0;
        }
    }
}