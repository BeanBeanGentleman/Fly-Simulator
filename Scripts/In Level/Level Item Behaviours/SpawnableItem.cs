using UnityEngine;

namespace In_Level.Level_Item_Behaviours.Ingestable
{
    [RequireComponent(typeof(Collider))]
    public class SpawnableItem : MonoBehaviour
    {
        public virtual bool IsOverlappingWith(SpawnableItem item)
        {
            return this.GetComponent<Collider>().bounds.Intersects(item.GetComponent<Collider>().bounds);
        }
    }
}