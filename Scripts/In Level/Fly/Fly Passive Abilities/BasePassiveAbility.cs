using System;
using System.Collections.Generic;
using Genral;
using UnityEngine;

namespace In_Level.Fly.Fly_Passive_Abilities
{
    public abstract partial class BasePassiveAbility : MonoBehaviour
    {
        public Guid guid;
        public List<Modifier> BuffValue;
        public List<Modifier> DebuffValue;
        public ValueContainer FinalBuffValue;
        public ValueContainer FinalDebuffValue;
        
        public BaseFlyController thisFlyController;
        
        protected virtual void Start()
        {
            guid = Guid.NewGuid();
            if (thisFlyController == null)
            {
                thisFlyController = this.gameObject.GetComponent<BaseFlyController>();
                if (thisFlyController == null)
                {
                    Debug.LogError("CANNOT FIND FLY CONTROLLER ON THIS GAME OBJECT!");
                    Destroy(this);
                }
            }
            
        }

        protected virtual void Update()
        {
        }

        protected virtual void FixedUpdate()
        {
            Active();
        }
        
        protected abstract void Active();
        
    }
}