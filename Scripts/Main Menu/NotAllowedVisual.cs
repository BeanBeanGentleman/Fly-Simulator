using System;
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
        [HideInInspector]
        public List<List<float>> Freqs = new List<List<float>>
        {
            new List<float> {16.352f, 32.703f, 65.406f, 130.81f, 261.63f, 523.25f, 1046.5f, 2093.0f, 4186.0f, 8372.0f},
            new List<float> {18.354f, 36.708f, 73.416f, 146.83f, 293.66f, 587.33f, 1174.7f, 2349.3f, 4698.6f, 9397.3f},
            new List<float> {20.602f, 41.203f, 82.407f, 164.81f, 329.63f, 659.26f, 1318.5f, 2637.0f, 5274.0f, 10548},
            new List<float> {21.827f, 43.654f, 87.307f, 174.61f, 349.23f, 698.46f, 1396.9f, 2793.8f, 5587.7f, 11175},
            new List<float> {24.500f, 48.999f, 97.999f, 196.00f, 392.00f, 783.99f, 1568.0f, 3136.0f, 6271.9f, 12544},
            new List<float> {27.500f, 55.000f, 110.00f, 220.00f, 440.00f, 880.00f, 1760.0f, 3520.0f, 7040.0f, 14080},
            new List<float> {30.868f, 61.735f, 123.47f, 246.94f, 493.88f, 987.77f, 1975.5f, 3951.1f, 7902.1f, 15804}
        };
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
        public float SpecOffsetRangeFromGivenRatio = 0.2f;

        public bool MusicSamplingMethod = false;
    
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

                if (MusicSamplingMethod)
                {
                    UpdateLengthWidth(linee.rectTransform, ((float) count) * lIneeeCountInverse, SpecTakingRangeFromGivenRatio, FrameSpecData);
                }
                else
                {
                    UpdateLengthWidth(linee.rectTransform, count, SpecOffsetRangeFromGivenRatio, FrameSpecData);
                }
                
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
        
        void UpdateLengthWidth(RectTransform GivenTransform, int index, float offsetRange, float[] FrameSpecData)
        {
            if (FrameSpecData != null)
            {
                float height = 0;

                index = index % (Freqs.Count - 1);
                List<float> freqz = Freqs[index];

                foreach (var freq in freqz)
                {
                    float lowerBound = (freq * (1 - offsetRange));
                    float higherBound = (freq * (1 + offsetRange));
                    float lengthClamped = (float)(FrameSpecData.Length) / 20000;
                    for (int i = (int)(lengthClamped * lowerBound); i < lengthClamped * higherBound; ++i)
                    {
                        i = Mathf.Clamp(i, 0, FrameSpecData.Length);
                        height += FrameSpecData[i];
                    }
                }
                

                // height = Mathf.Clamp(height, 0.1f, 10000f) ;
                // GivenTransform.localScale = new Vector3(DefaultDimension.x * height, Mathf.Clamp(DefaultDimension.y * height, 0.001f, 0.1f), 1);
                GivenTransform.sizeDelta = new Vector2(DefaultDimension.x * (1 + (height * 5)), DefaultDimension.y * (1 + (height * 2) - 0.5f));
                
                // print($"H: {height} INDEX: {index}");
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

