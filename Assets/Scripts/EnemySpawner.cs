using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Zenject;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private List<Wave> _waves;
    [Inject] private Player _target;

    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _intervalBetweenWaves;
    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private float _timeAfterLastSpawn;
    private float _timeBetweenWaves;
    private int _spawned;

    private bool _isAllEnemyInCurrentSessionDie = false;

    public event UnityAction<int, int> EnemyCountChanged;
    public event UnityAction AllEnemyInCurrentSessionDie;
   
    private void Start()
    {
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        SpawnWithSpread();
    }

    private void SpawnWithSpread()
    {
        if (IsAllEnemyInCurrentWaveDie)
        {
            _timeBetweenWaves += Time.deltaTime;
            
            if (_waves.Count > _currentWaveIndex + 1 && _timeBetweenWaves >= _intervalBetweenWaves)
            {
                Debug.Log("Next wave");
                _timeBetweenWaves = 0;
                
                NextWave();
            }
            else
            {
                if (_isAllEnemyInCurrentSessionDie)
                    return;
                
                AllEnemyInCurrentSessionDie?.Invoke();
                Debug.Log("You win");
            }
        }

        if (_currentWave.IsNull)
            return;

        _timeAfterLastSpawn += Time.deltaTime;
        
        if (_timeAfterLastSpawn >= _currentWave.DelayBetweenSpawn)
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

        if (!_currentWave.IsNull)
        {
            if (_currentWave.Count <= _spawned)
            {
                Debug.Log($"null spawn {_currentWave}, {_currentWave.IsNull}");
                _currentWave.IsNull = true;
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
        enemy.GetComponent<Enemy>().Init(_target);
    }

    private void SetWave(int index)
    {
        Debug.Log($"Current wave index: {index}");
        _currentWave = _waves[index];

        EnemyCountChanged?.Invoke(0, 1);
        Initialize(_currentWave.Templates, _currentWave.Count);
    }

    private void NextWave()
    {
        SetWave(++_currentWaveIndex);

        _spawned = 0;
    }
}

[System.Serializable]
public class Wave
{
    public List<GameObject> Templates;
    public float DelayBetweenSpawn;
    public int Count;
    public bool IsNull = false;
}