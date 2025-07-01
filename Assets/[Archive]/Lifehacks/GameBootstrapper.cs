using UnityEngine;

namespace _Archive_.Lifehacks
{
    public class GameBootstrapper : MonoBehaviour
    {
        private ProgressBar _loadingProgress;
    
        [SerializeField]
        private GameObject _enemyPrefab;
    
        private void Start()
        {
            Debug.Log("Start game");
            var enemySpawner = new EnemySpawner(_enemyPrefab);
            _loadingProgress.Show();
        }
    }
}