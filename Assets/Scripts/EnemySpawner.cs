using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Zenject;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private List<Level> _levels;
    [Inject] private Player _target;

    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _intervalBetweenWaves;
    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private float _timeAfterLastSpawn;
    private float _timeBetweenWaves;
    private int _spawned;

    private bool _isAllEnemyInCurrentSessionDie = false;

    private Level _currentLevel;
    private int _currentLevelIndex = 0;
    
    public event UnityAction<int, int> EnemyCountChanged;
    public event UnityAction<int> LevelCountChanged;
    public event UnityAction AllEnemyInCurrentSessionDie;
   
    private void Start()
    {
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        InitLevel();
    }

    private void InitLevel()
    {
        SpawnWave();
    }
    
    // время придет
    private void SpawnWave()
    {
        if (IsAllEnemyInCurrentWaveDie)
        {
            _timeBetweenWaves += Time.deltaTime;
            
            if (_levels[_currentLevelIndex].Waves.Count > _currentWaveIndex + 1 && _timeBetweenWaves >= _intervalBetweenWaves)
            {
                _timeBetweenWaves = 0;
                NextWave();
            }
            else
            {
                AllEnemyInCurrentSessionDie?.Invoke();
                Debug.Log("AllEnemyInCurrentSessionDie");
                
                _currentLevelIndex++;

                if (_levels.Count < _currentLevelIndex)
                {
                    LevelCountChanged?.Invoke(_currentLevelIndex + 1);
                    _currentWaveIndex = -1;
                }
                else
                {
                    Debug.Log("AAAAAAAAAA");
                    return;
                }
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
        Debug.Log(index);
        _currentWave = _levels[_currentLevelIndex].Waves[index];

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

[System.Serializable]
public class Level
{
    public List<Wave> Waves;
}