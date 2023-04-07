using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnProgressBar : GameStatusBar
{
    [Inject] private EnemySpawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemyCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanged -= OnValueChanged;
    }
}
