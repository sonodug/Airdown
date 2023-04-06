using UnityEngine;
using TMPro;
using Zenject;

public class ProgressBar : Bar
{
    [Inject] private EnemySpawner _spawner;
    [SerializeField] private TMP_Text _waveCounterText;

    private static int _counter = 1;

    private void OnEnable()
    {
        _spawner.AllEnemyInCurrentWaveDied += SetWaveTextCount;
        _spawner.AllEnemyInCurrentWaveDied += ResetValue;
        _spawner.EnemyDieCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.AllEnemyInCurrentWaveDied -= SetWaveTextCount;
        _spawner.AllEnemyInCurrentWaveDied -= ResetValue;
        _spawner.EnemyDieCountChanged -= OnValueChanged;
    }

    private void SetWaveTextCount()
    {
        _counter++;
        string counter = _counter.ToString();
        _waveCounterText.text = "Wave: " + counter;
    }

    private void ResetValue()
    {
        Slider.value = 0;
        PrevValue = 0;
        CurrentValue = 0;
    }
}
