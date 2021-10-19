using UnityEngine;

namespace In_Level.Fly.Fly_Debuff
{
    public class DamageOverTimeScript : BaseDebuff
    {
        public BaseFlyController BFC;
        public float DamagePerSecond;
        public float LastingTime;
        protected override void Start()
        {
            base.Start();
            BFC = this.gameObject.GetComponent<BaseFlyController>();
            if (BFC == null)
            {
                DestroyImmediate(this);
                Debug.LogError("THIS DEBUFF HAS BEEN APPLIED TO A WRONG GAMEOBJECT!");
            }
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            BFC.TakeDamage(DamagePerSecond * Time.fixedDeltaTime);
        }

        protected override void OnDestroy()
        {
        }
    }
}