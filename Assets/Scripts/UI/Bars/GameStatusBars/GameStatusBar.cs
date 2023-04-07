using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameStatusBar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] private float _lerpDuration;

    private bool _isReadyToChange = false;

    protected int CurrentValue;
    protected int PrevValue;
    private int _maxValue; 
        
    private float _timeElapsed;
    
    private void Update()
    {
        if (_timeElapsed < _lerpDuration && _isReadyToChange)
        {
            Slider.value = Mathf.Lerp((float)PrevValue / _maxValue, (float)CurrentValue / _maxValue, _timeElapsed / _lerpDuration);
            _timeElapsed += Time.deltaTime;
        }
        else if (_isReadyToChange)
        {
            Slider.value = (float)CurrentValue / _maxValue;
            PrevValue = CurrentValue;
            _isReadyToChange = false;
            _timeElapsed = 0;
        }
    }

    public virtual void OnValueChanged(int value, int maxValue)
    {
        CurrentValue = value;
        _maxValue = maxValue;
        _isReadyToChange = true;
    }
}
