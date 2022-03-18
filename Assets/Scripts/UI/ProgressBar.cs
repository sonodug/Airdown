using UnityEngine;
using TMPro;

public class ProgressBar : Bar
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private TMP_Text _text;

    private static int _counter = 1;

    private void OnEnable()
    {
        _spawner.AllEnemyInCurrentWaveDied += SetWaveTextCount;
        _spawner.AllEnemyInCurrentWaveDied += ResetValue;
        _spawner.EnemyDyingCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.AllEnemyInCurrentWaveDied -= SetWaveTextCount;
        _spawner.AllEnemyInCurrentWaveDied -= ResetValue;
        _spawner.EnemyDyingCountChanged -= OnValueChanged;
    }

    public void SetWaveTextCount()
    {
        _counter++;
        string counter = _counter.ToString();
        _text.text = "Wave: " + counter;
    }

    public void ResetValue()
    {
        Slider.value = 0;
    }
}
