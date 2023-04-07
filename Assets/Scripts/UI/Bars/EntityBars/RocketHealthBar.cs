using UnityEngine;

public class RocketHealthBar : EntityBar
{
    [SerializeField] private SelfGuidedRocket _rocket;
    
    private void OnEnable()
    {
        _rocket.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _rocket.HealthChanged -= OnValueChanged;
    }
}