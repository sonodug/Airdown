using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private EnemySpawner _spawner;
   

    private void OnEnable()
    {
        _spawner.EnemyDyingCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.EnemyDyingCountChanged -= OnValueChanged;
    }
}
