using System;
using UnityEngine;

namespace Game.Engine
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract event Action OnFire;

        public abstract void Fire();

        public abstract bool CanFire();
    }
}