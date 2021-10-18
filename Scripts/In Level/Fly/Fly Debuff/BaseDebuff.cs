using System;
using UnityEngine;

namespace In_Level.Fly.Fly_Debuff
{
    public abstract class BaseDebuff : MonoBehaviour
    {
        public AutoResetCounter DebuffTimeLeft = new AutoResetCounter(1);
        
        protected Guid thisGuid;

        protected virtual void Start()
        {
            thisGuid = Guid.NewGuid();
        }

        protected virtual void FixedUpdate()
        {
            if (DebuffTimeLeft.IsZeroReached(Time.fixedDeltaTime))
            {
                Destroy(this);
            }

            // ReduceEffect();
        }

        protected virtual void OnDestroy()
        {
            
        }

        protected virtual void ReduceEffect()
        {
            
        }
    }
}