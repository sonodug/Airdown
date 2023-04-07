using UnityEngine;
using UnityEngine.UI;

public class EntityBar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] private float _lerpDuration;

    private bool _isReadyToChange = false;

    protected float CurrentValue;
    protected float PrevValue;
    private float _maxValue; 
        
    private float _timeElapsed;
    
    private void Update()
    {
        if (_timeElapsed < _lerpDuration && _isReadyToChange)
        {
            Slider.value = Mathf.Lerp(PrevValue / _maxValue, CurrentValue / _maxValue, _timeElapsed / _lerpDuration);
            _timeElapsed += Time.deltaTime;
        }
        else if (_isReadyToChange)
        {
            Slider.value = CurrentValue / _maxValue;
            PrevValue = CurrentValue;
            _isReadyToChange = false;
            _timeElapsed = 0;
        }
    }

    public void OnValueChanged(float value, float maxValue)
    {
        CurrentValue = value;
        _maxValue = maxValue;

        if (PrevValue == 0)
            PrevValue = _maxValue;
        
        _isReadyToChange = true;
    }
}