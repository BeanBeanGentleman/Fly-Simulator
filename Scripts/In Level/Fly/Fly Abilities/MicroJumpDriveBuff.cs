using UnityEngine;
using UnityEngine.Rendering;

namespace In_Level.Fly.Fly_Abilities
{
    public class MicroJumpDriveBuff : BaseManeuverabilityBuff
    {
        private bool DoJump = false;
        private float Distance = 0;
        private GameObject ballball;

        protected override void Start()
        {
            base.Start();
            ballball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ballball.transform.position = Vector3.down * 10000;
            ballball.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.Off;
        }

        protected override void Active()
        {
            DoJump = true;
            Distance = Mathf.Min(BuffValue[0].Value, Distance + BuffValue[1].Value);
            ballball.transform.position = this.gameObject.transform.position + this.transform.forward * Distance;
            ballball.transform.localScale = Vector3.one * Mathf.Sqrt(Distance/10);
        }

        protected override void Deactive()
        {
            if (DoJump)
            {
                //TODO: Cast ray and detect hit
                this.gameObject.transform.position += this.transform.forward * Distance;
                DoJump = false;
                Distance = 0;
            }

            ballball.transform.position = Vector3.down * 10000;
            ballball.GetComponent<Collider>().isTrigger = true;
        }
    }
}