using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<GameObject> _pool = new List<GameObject>();
    private static int _enemyDieCounter = 0;

    public bool IsAllEnemyDie { get; private set; }

    public event UnityAction<int, int> EnemyDyingCountChanged;
    public event UnityAction AllEnemyInCurrentWaveDied;

    protected void Initialize(List<GameObject> prefabs, int count)
    {
        IsAllEnemyDie = false;
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

    public void DieCountChanged()
    {
        _enemyDieCounter++;
        Debug.Log(_enemyDieCounter);
        Debug.Log(_pool.Count);
        EnemyDyingCountChanged?.Invoke(_enemyDieCounter, _pool.Count);
        if (_enemyDieCounter == _pool.Count)
        {
            IsAllEnemyDie = true;
            AllEnemyInCurrentWaveDied?.Invoke();
        }
    }
}
