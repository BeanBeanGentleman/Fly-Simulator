using System;
using System.Collections.Generic;
using Genral;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Control
{
    public abstract class BaseAbilityController : MonoBehaviour
    {
        public readonly GUID guid = new GUID();
        public List<InputAction> ActivationActions;
        public AutoResetCounter ActivationTime;
        public AutoResetCounter CDTime;
        public List<float> BuffValue;
        public List<float> DebuffValue;

        public FlyValueContainer ActivationTimeModifier;
        public FlyValueContainer CDTimeModifier;

        public BaseFlyController thisFlyController;

        protected bool Activated = false;

        protected virtual void Start()
        {
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
            bool pressed = false;
            foreach (InputAction action in ActivationActions)
            {
                pressed = pressed || (action.ReadValue<float>() > 0.75f);
            }

            Activated = CDTime.IsZeroReached(Time.deltaTime, false) && pressed;

            _ = Activated ? Active() : Deactive();

            if (Activated)
            {
                if (ActivationTime.IsZeroReached(Time.deltaTime, false))
                {
                    CDTime.MaxmizeTemp(); // Will force stop activation
                    Deactive();
                }
            }
            
        }

        protected virtual void FixedUpdate()
        {
            _ = Activated ? Active() : Deactive();
        }

        protected abstract float Active();
        protected abstract float Deactive();
    }
}