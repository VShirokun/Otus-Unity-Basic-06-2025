using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MonoFoo : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; private set; }

    [SerializeField] private Transform _building;
    [SerializeField] private Rigidbody _player;
    
    [SerializeField]
    // [Range(0, 100)]
    [ProgressBar(0, 10)]
    private float _speedRate;

    [Button]
    private void StartGame()
    {
        Speed = 10;
        var maxSpeed = 20;
        var text = "Player speed = " + Speed + "/" + maxSpeed;
        var speedText = $"Player speed = {Speed}/{maxSpeed}";
        Debug.Log(text);
        Debug.Log(speedText);
        
        _building.gameObject.SetActive(false);
        _player.gameObject.SetActive(false);
        
        _player.Deactivate();

        List<Transform> spawnPoints = new List<Transform>();
        spawnPoints.Add(FindObjectOfType<Transform>());
        var spawnPoint = spawnPoints.GetRandom();
    }

    public void Update()
    {
        _speedRate += Time.deltaTime;
        
        if (_speedRate >= 10)
        {
            _speedRate = 0f;
            
            
        }
    }
}