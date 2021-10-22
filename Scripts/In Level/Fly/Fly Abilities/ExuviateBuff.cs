using UnityEngine;
using UnityEngine.InputSystem;

namespace In_Level.Fly.Fly_Abilities
{
    public class ExuviateBuff : BaseUltimateBuff
    {
        // TODO: CD is debuffvalue[0], nonmoveable is debuffvalue[1]
        public override void OnUse(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started && !Activated)
            {
                ShouldAct = !ShouldAct;
            }
        }
        protected override object _active(float TimeDelta)
        {
            // TODO: if sum of the food is not enough then we deactivate immediately.
            float sum = 0;
            foreach (var amount in thisFlyController.IngestedValues.Values)
            {
                sum += amount;
            }

            if (sum < 100)
            {
                _deactive();
                return 0;
            }
            thisFlyController.ClearIngestion();
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

        protected override void Active()
        {
            // TODO: HPReceptionModifier
            throw new System.NotImplementedException();
        }

        protected override void Deactive()
        {
            throw new System.NotImplementedException();
        }
    }
}