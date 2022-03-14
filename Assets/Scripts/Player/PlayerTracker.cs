using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Vector3 _targetPosition;

    private void Awake()
    {
        if (!_player)
        {
            _player = FindObjectOfType<Player>();
        }
    }

    private void Update()
    {
        _targetPosition = _player.transform.position;
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + 4.0f, -10.0f);

        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime);
    }
}
