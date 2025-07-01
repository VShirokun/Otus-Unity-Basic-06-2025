using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(Collider))]
    public sealed class EnemyTrigger : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] enemies;

        private void OnTriggerEnter(Collider other)
        {
           
            var character = other.GetComponentInParent<CharacterMarker>();
            if (character != null)
            {
                this.SetTargetToEnemies(character.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var character = other.GetComponentInParent<CharacterMarker>();
            if (character != null)
            {
                this.ResetTargetOfEnemies();
            }
        }

        private void SetTargetToEnemies(GameObject player)
        {
            for (int i = 0, count = this.enemies.Length; i < count; i++)
            {
                GameObject enemy = this.enemies[i];
                if (enemy == null)
                {
                    continue;
                }
                
                TargetComponent component = enemy.GetComponentInChildren<TargetComponent>();
                if (component != null)
                {
                    component.SetTarget(player);
                }
            }
        }

        private void ResetTargetOfEnemies()
        {
            for (int i = 0, count = this.enemies.Length; i < count; i++)
            {
                GameObject enemy = this.enemies[i];
                TargetComponent component = enemy.GetComponentInChildren<TargetComponent>();
                if (component != null)
                {
                    component.ResetTarget();
                }
            }
        }
    }
}