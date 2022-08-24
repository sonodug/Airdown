using UnityEngine;
using TMPro;
using Zenject;

public class ProgressBar : Bar
{
    [Inject] private EnemySpawner _spawner;
    [SerializeField] private TMP_Text _text;

    private static int _counter = 1;

    private void OnEnable()
    {
        Debug.Log("sub");
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

    public void SetWaveTextCount()
    {
        Debug.Log("hand");
        _counter++;
        string counter = _counter.ToString();
        _text.text = "Wave: " + counter;
    }

    public void ResetValue()
    {
        Slider.value = 0;
    }
}
