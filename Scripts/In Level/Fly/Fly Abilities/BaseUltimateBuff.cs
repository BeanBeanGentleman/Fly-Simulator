using UnityEngine;
using UnityEngine.InputSystem;

namespace Control
{
    public abstract class BaseUltimateBuff : BaseAbilityController, FlyAbilityControl.IUltimateAbilityActions
    {
        private FlyAbilityControl _FlyInputActions;
        public void Awake()
        {
            _FlyInputActions = new FlyAbilityControl();
            _FlyInputActions.UltimateAbility.SetCallbacks(this);
        }
    
        public void OnEnable()
        {
            _FlyInputActions.UltimateAbility.Enable();
        }

        public void OnDisable()
        {
            _FlyInputActions.UltimateAbility.Disable();
        }

        public virtual void OnUse(InputAction.CallbackContext context)
        {
            Activation += 1;
        }
    }
}