using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace Asset.Scripts
{
    public class NotAllowedVisual : MonoBehaviour
    {
        public List<Image> LIneee;
        private Dictionary<Image, ModifyHammer> LineControl = new Dictionary<Image, ModifyHammer>();
        public RectTransform Container;
    
        public float SpeedLimit = 5;
        public float AngSpeedLimit = 3;

        public float ChangeMultiplier = 0.2f;
        public float ChangeAngMultiplier = 0.05f;

        private float stuff = 0;
    
        // Start is called before the first frame update
        private void Start()
        {
            foreach (var VARIABLE in LIneee)
            {
                LineControl.Add(VARIABLE, new ModifyHammer(new Vector3(VARIABLE.transform.position.x - Container.position.x, VARIABLE.transform.position.y - 
                Container.position.y,
                (Random.value - 0.5f) * 20)));
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            bool uuu = false;
            foreach (Image linee in LineControl.Keys)
            {
                Vector3 thisV3 = LineControl[linee].Hammer;
                linee.rectTransform.position = Vector3.Lerp( linee.rectTransform.position,  new Vector3(thisV3.x, thisV3.y, 0), 0.0002f);
                thisV3 = new Vector3(
                    Mathf.Clamp(thisV3.x, -Container.rect.width/2 + Container.position.x, Container.rect.width/2 + Container.position.x),
                    Mathf.Clamp(thisV3.y, -Container.rect.height/2  + Container.position.y, Container.rect.height/2+ + Container.position
                    .y),
                    thisV3.z
                );
                linee.rectTransform.eulerAngles += Vector3.forward * thisV3.z;
                if (((int) ((Time.time * 10) + stuff)) % (int)(Random.Range(15, 35)) == 0)
                {
                    thisV3 += Vector3.right * Mathf.Clamp(((Random.value - 0.5f) * ChangeMultiplier), -SpeedLimit, SpeedLimit);
                    thisV3 += Vector3.up * Mathf.Clamp(((Random.value - 0.5f) * ChangeMultiplier), -SpeedLimit, SpeedLimit);

                    uuu = true;
                }
                thisV3 += Vector3.forward * (Random.value - 0.5f) * ChangeAngMultiplier;
                thisV3 = new Vector3(
                    thisV3.x,
                    thisV3.y,
                    Mathf.Clamp(thisV3.z, -AngSpeedLimit, AngSpeedLimit)
                );
    
                LineControl[linee].Hammer = thisV3;
    
            }

            stuff += uuu ? 1 : 0;
        }
    }
    
    class ModifyHammer
    {
        public Vector3 Hammer;
    
        public ModifyHammer(Vector3 Hummer)
        {
            Hammer = Hummer;
        }
    }
}

