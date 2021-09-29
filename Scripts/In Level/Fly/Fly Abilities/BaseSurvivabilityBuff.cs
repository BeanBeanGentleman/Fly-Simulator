using UnityEngine;
using UnityEngine.InputSystem;

namespace Control
{
    public abstract class BaseSurvivabilityBuff : BaseAbilityController, FlyAbilityControl.ISurviabilityAbilityActions
    {
        private FlyAbilityControl _FlyInputActions;
        public void Awake()
        {
            _FlyInputActions = new FlyAbilityControl();
            _FlyInputActions.SurviabilityAbility.SetCallbacks(this);
        }
    
        public void OnEnable()
        {
            _FlyInputActions.SurviabilityAbility.Enable();
        }

        public void OnDisable()
        {
            _FlyInputActions.SurviabilityAbility.Disable();
        }
        public virtual void OnUse(InputAction.CallbackContext context)
        {
            Activation += 1;
        }
    }
}