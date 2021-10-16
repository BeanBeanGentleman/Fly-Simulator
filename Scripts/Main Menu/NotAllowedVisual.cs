using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
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


        public AudioSource TheAudSource;
        public Vector2 DefaultDimension;

        public int SpecMaxCount = 128;
        public float SpecTakingRangeFromGivenRatio = 0.1f;
    
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
            float lIneeeCountInverse = (1/(float)LIneee.Count);
            
            bool uuu = false;
            int count = 0;
            float[] FrameSpecData = LocalGetSpectrumData();
            foreach (Image linee in LineControl.Keys)
            {
                Vector3 thisV3 = LineControl[linee].TempV3Storage;
                linee.rectTransform.position = Vector3.Lerp( linee.rectTransform.position,  new Vector3(thisV3.x, thisV3.y, 0), 0.0002f);
                thisV3 = new Vector3(
                    Mathf.Clamp(thisV3.x, -Container.rect.width/2 + Container.position.x, Container.rect.width/2 + Container.position.x),
                    Mathf.Clamp(thisV3.y, -Container.rect.height/2  + Container.position.y, Container.rect.height/2+ + Container.position
                    .y),
                    thisV3.z
                );
                linee.rectTransform.eulerAngles += Vector3.forward * thisV3.z;


                UpdateLengthWidth(linee.rectTransform, ((float) count) * lIneeeCountInverse, SpecTakingRangeFromGivenRatio, FrameSpecData);
                
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
    
                LineControl[linee].TempV3Storage = thisV3;
                count++;
            }

            stuff += uuu ? 1 : 0;
        }

        float[] LocalGetSpectrumData()
        {
            if (TheAudSource == null)
            {
                return null;
            }

            float time = TheAudSource.time;
            float Ratio = (time / TheAudSource.clip.length);
            float SamplesPerSec = TheAudSource.clip.samples / TheAudSource.clip.length;
            int SampleOffset = (int)(Ratio * TheAudSource.clip.samples);
            float[] CurrentData = new float[2048];
            TheAudSource.GetSpectrumData(CurrentData, 0, FFTWindow.Blackman);
            return CurrentData.Take(SpecMaxCount).ToArray();
            // 音量谱?
        }

        void UpdateLengthWidth(RectTransform GivenTransform, float ratio, float range, float[] FrameSpecData)
        {
            if (FrameSpecData != null)
            {
                float height = 0;
                
                for (int i = (int)(FrameSpecData.Length * Mathf.Clamp01(ratio - range)); i < FrameSpecData.Length * Mathf.Clamp01(ratio + range); ++i)
                {
                    height += FrameSpecData[i];
                }
                height = Mathf.Clamp(height, 0.1f, 10000f) * 5;
                // GivenTransform.localScale = new Vector3(DefaultDimension.x * height, Mathf.Clamp(DefaultDimension.y * height, 0.001f, 0.1f), 1);
                GivenTransform.sizeDelta = new Vector2(DefaultDimension.x * height, Mathf.Clamp(DefaultDimension.y * height, 100f, 2000f));
            }
        }
    }
    
    class ModifyHammer
    {
        public Vector3 TempV3Storage;
    
        public ModifyHammer(Vector3 Hummer)
        {
            TempV3Storage = Hummer;
        }
    }
}

