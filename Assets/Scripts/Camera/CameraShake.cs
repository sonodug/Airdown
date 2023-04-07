using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    [Inject] private Player _player;
    [SerializeField] private float _duration;
    [SerializeField] private float _magnitude;
    [SerializeField] private float _decreaseFactor;

    private Vector3 _originalPosition;
    private float _tempDuration;
    
    private void OnEnable()
    {
        _player.Damaged += OnDamaged;
        _originalPosition = transform.localPosition;
        _tempDuration = _duration;
    }

    private void OnDisable()
    {
        _player.Damaged -= OnDamaged;
    }

    private void OnDamaged(float damage)
    {
        StartCoroutine(Shake(damage));
    }
    
    public IEnumerator Shake(float damage)
    {
        while (_duration > 0)
        {
            float damageFactor = damage / 5.0f;
            transform.localPosition = _originalPosition + Random.insideUnitSphere * (_magnitude * damageFactor);
            _duration -= Time.deltaTime * _decreaseFactor;
            yield return null;
        }

        _duration = _tempDuration;
        transform.localPosition = _originalPosition;
    }
}