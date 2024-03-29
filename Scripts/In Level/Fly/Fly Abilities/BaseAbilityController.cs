﻿using System;
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
        public Guid guid;
        public bool ShouldAct = false;
        public AutoResetCounter ActivationTime;
        public AutoResetCounter CDTime;
        public List<Modifier> BuffValue;
        public List<Modifier> DebuffValue;

        public ValueContainer ActivationTimeModifier;
        public ValueContainer CDTimeModifier;

        public BaseFlyController thisFlyController;

        protected bool Activated = false;

        protected bool OnceDeactivated = false;

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
            Activated = CDTime.IsZeroReached(Time.deltaTime, false) && ShouldAct;
            ShouldAct = (Activated) && ShouldAct;
        }

        protected virtual void FixedUpdate()
        {
            _ = Activated ? _active(Time.fixedDeltaTime) : _deactive(); // Will have the ability automatically stop if released
        }

        protected object _active(float TimeDelta)
        {
            if (ActivationTime.Temp < 0)
            {
                ActivationTime.MaxmizeTemp();
                OnceDeactivated = false;
            }
            Active();
            if(ActivationTime.IsZeroReached(TimeDelta, false, true)) // Will force stop activation
            {
                _deactive();
            }

            return null;
        }
        
        protected object _deactive()
        {
            ActivationTime.Temp = -1;
            if (!OnceDeactivated)
            {
                CDTime.MaxmizeTemp();
                OnceDeactivated = true;
            }

            Deactive();
            return null;
        }

        protected abstract void Active();
        protected abstract void Deactive();
    }
}