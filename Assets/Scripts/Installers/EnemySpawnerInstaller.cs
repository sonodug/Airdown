using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private EnemySpawner _enemySpawner;

    public override void InstallBindings()
    {
        Container.
            Bind<EnemySpawner>().
            FromInstance(_enemySpawner)
            .AsCached()
            .NonLazy();
    }
 }