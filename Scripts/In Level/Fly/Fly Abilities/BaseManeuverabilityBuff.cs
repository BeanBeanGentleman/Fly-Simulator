using UnityEngine;
using UnityEngine.InputSystem;

namespace Control
{
    public abstract class BaseManeuverabilityBuff : BaseAbilityController, FlyAbilityControl.IManeuverabilityAbilityActions
    {
        private FlyAbilityControl _FlyInputActions;
        public void Awake()
        {
            _FlyInputActions = new FlyAbilityControl();
            _FlyInputActions.ManeuverabilityAbility.SetCallbacks(this);
        }
    
        public void OnEnable()
        {
            _FlyInputActions.ManeuverabilityAbility.Enable();
        }

        public void OnDisable()
        {
            _FlyInputActions.ManeuverabilityAbility.Disable();
        }

        public virtual void OnUse(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                ShouldAct = !ShouldAct;
            }
        }
    }
}