using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace In_Level.Fly.Fly_Abilities
{
    public class OversensingBuff : BaseSurvivabilityBuff
    {
        public AudioSource VFXTimeSlowDown;
        public PostProcessVolume PostProcessing;

        private bool played;
        protected override void Active()
        {
            thisFlyController.movementAccel.SetModifier(this.guid, BuffValue[0]);
            thisFlyController.Agility.SetModifier(this.guid, BuffValue[0]);
            Time.timeScale = Mathf.Max(BuffValue[1].Value, Time.timeScale * 0.9f);
            thisFlyController.TakeDamage(DebuffValue[0].Value * Time.fixedDeltaTime);
            if (VFXTimeSlowDown != null)
            {
                if((!VFXTimeSlowDown.isPlaying) && (!played))
                {
                    VFXTimeSlowDown.Play();
                    played = true;
                }
            }
            else
            {
                Debug.LogError("VFX for Oversensing Does Not Exist.");
            }

            if (PostProcessing != null)
            {
                PostProcessing.profile.GetSetting<ChromaticAberration>().intensity.value = Mathf.Lerp(PostProcessing.profile.GetSetting<ChromaticAberration>
                    ().intensity.value, 3f, 0.2f);
            }
            else
            {
                Debug.LogError("PostProcessing for Oversensing Does Not Exist.");
            }

        }

        protected override void Deactive()
        {
            Time.timeScale = Mathf.Min(1f, Time.timeScale / 0.9f);
            thisFlyController.movementAccel.SetNoBonusModifier(this.guid);
            thisFlyController.Agility.SetNoBonusModifier(this.guid);
            if (VFXTimeSlowDown != null)
            {
                VFXTimeSlowDown.Stop();
                played = false;
            }
            if (PostProcessing != null)
            {
                PostProcessing.profile.GetSetting<ChromaticAberration>().intensity.value = Mathf.Lerp(PostProcessing.profile.GetSetting<ChromaticAberration>
                    ().intensity.value, 0.01f, 0.2f);
            }
        }
    }
}