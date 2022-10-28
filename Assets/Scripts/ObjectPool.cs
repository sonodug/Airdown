using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private readonly List<GameObject> _pool = new List<GameObject>();
    private static int _enemyDieCounter = 0;
    private int _poolOffset;

    protected bool IsAllEnemyInCurrentWaveDie { get; private set; }

    public event UnityAction<int, int> EnemyDieCountChanged;
    public event UnityAction AllEnemyInCurrentWaveDied;

    protected void Initialize(List<GameObject> prefabs, int count)
    {
        Debug.Log($"Current wave count {count}");
        _poolOffset = count;
        IsAllEnemyInCurrentWaveDie = false;

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Count);
            GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);
            spawned.SetActive(false);

            spawned.GetComponent<Enemy>().Died += DieCountChanged;
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

    private void DieCountChanged()
    {
        _enemyDieCounter++;
        EnemyDieCountChanged?.Invoke(_enemyDieCounter, _poolOffset);

        if (_enemyDieCounter == _poolOffset)
        {
            _enemyDieCounter = 0;
            Debug.Log("AllEnemyInCurrentWaveDied");
            IsAllEnemyInCurrentWaveDie = true;
            AllEnemyInCurrentWaveDied?.Invoke();
        }
    }
}
