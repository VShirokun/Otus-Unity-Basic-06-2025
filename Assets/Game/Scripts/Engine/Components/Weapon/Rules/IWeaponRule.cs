using UnityEngine;

namespace Game.Engine
{
    public interface IWeaponRule
    {
        void OnEnable(GameObject owner, Weapon weapon);
        
        void OnDisable(GameObject owner, Weapon weapon);

        void Update(GameObject owner, Weapon weapon);

        void FixedUpdate(GameObject owner, Weapon weapon);

        void LateUpdate(GameObject owner, Weapon weapon);
    }
}