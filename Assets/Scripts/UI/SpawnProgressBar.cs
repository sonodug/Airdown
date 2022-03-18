using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProgressBar : Bar
{
    [SerializeField] private EnemySpawner _spawner;

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
