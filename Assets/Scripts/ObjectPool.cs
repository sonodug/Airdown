<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
=======
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
>>>>>>> dev

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<GameObject> _pool = new List<GameObject>();
<<<<<<< HEAD

    protected void Initialize(List<GameObject> prefabs, int count)
    {
=======
    private static int _enemyDieCounter = 0;
    private int _poolOffset;

    public bool IsAllEnemyDie { get; private set; }

    public event UnityAction<int, int> EnemyDieCountChanged;
    public event UnityAction AllEnemyInCurrentWaveDied;

    protected void Initialize(List<GameObject> prefabs, int count)
    {
        _poolOffset = count;
        IsAllEnemyDie = false;

>>>>>>> dev
        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Count);
            GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);
            spawned.SetActive(false);

<<<<<<< HEAD
=======
            spawned.GetComponent<Enemy>().Died += DieCountChanged;
>>>>>>> dev
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
<<<<<<< HEAD
=======

    public void DieCountChanged()
    {
        _enemyDieCounter++;
        EnemyDieCountChanged?.Invoke(_enemyDieCounter, _poolOffset);

        if (_enemyDieCounter == _poolOffset)
        {
            _enemyDieCounter = 0;
            Debug.Log("a");
            IsAllEnemyDie = true;
            AllEnemyInCurrentWaveDied?.Invoke();
        }
    }
>>>>>>> dev
}
