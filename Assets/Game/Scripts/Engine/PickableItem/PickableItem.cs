using UnityEngine;

namespace Game.Engine
{
    public abstract class PickableItem : MonoBehaviour
    {
        public abstract string Id { get; }

        public abstract bool PickUp(GameObject target);
    }
}