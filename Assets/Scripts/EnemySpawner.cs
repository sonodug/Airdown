using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _player;

    [SerializeField] private List<Transform> _spawnPoints;

    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private float _intervalBetweenWaves;

    public event UnityAction AllEnemyDied;
    public event UnityAction<int, int> EnemyCountChanged;
   
    private void Start()
    {
        SetWave(_currentWaveIndex);
        Initialize(_currentWave.Templates, _currentWave.Count);
    }

    private void Update()
    {
        SpawnWithSpread();
    }

    private void SpawnWithSpread()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            if (TryGetObject(out GameObject enemy))
            {
                int spawnPointIndex = Random.Range(0, _spawnPoints.Count);

                SetEnemy(enemy, _spawnPoints[spawnPointIndex].position);

                _spawned++;
                _timeAfterLastSpawn = 0;
                EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
            }
        }

        if (_currentWave.Count <= _spawned)
        {
            _currentWave = null;
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
        enemy.GetComponent<Enemy>().Init(_player);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    private void NextWave()
    {
        SetWave(_currentWaveIndex);
        _spawned = 0;
    }
}

[System.Serializable]
public class Wave
{
    public List<GameObject> Templates;
    public float Delay;
    public int Count;
}