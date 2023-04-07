using UnityEngine;
using TMPro;
using Zenject;

public class ProgressBar : GameStatusBar
{
    [Inject] private EnemySpawner _spawner;
    [SerializeField] private TMP_Text _waveCounterText;
    [SerializeField] private TMP_Text _levelCounterText;

    private static int _counter = 1;

    private void OnEnable()
    {
        _spawner.AllEnemyInCurrentWaveDied += SetWaveTextCount;
        _spawner.AllEnemyInCurrentWaveDied += ResetSliderValue;
        
        _spawner.LevelCountChanged += SetLevelTextCount;
        
        _spawner.EnemyDieCountChanged += OnValueChanged;
        _spawner.AllEnemyInCurrentSessionDie += ResetWaveTextValue;
        Slider.value = 0;
    }

    private void SetLevelTextCount(int count)
    {
        _levelCounterText.text = "S: " + count;
    }

    private void OnDisable()
    {
        _spawner.AllEnemyInCurrentWaveDied -= SetWaveTextCount;
        _spawner.AllEnemyInCurrentWaveDied -= ResetSliderValue;
        _spawner.EnemyDieCountChanged -= OnValueChanged;
    }

    private void SetWaveTextCount()
    {
        _counter++;
        _waveCounterText.text = "Wave: " + _counter;
    }

    private void ResetSliderValue()
    {
        Slider.value = 0;
        PrevValue = 0;
        CurrentValue = 0;
    }

    private void ResetWaveTextValue()
    {
        _counter = 1;
        _waveCounterText.text = "Wave: " + _counter;
    }
}
