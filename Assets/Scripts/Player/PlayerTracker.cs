using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
=======
using Zenject;

public class PlayerTracker : MonoBehaviour
{
    [Inject] private Player _player;
>>>>>>> dev
    private Vector3 _targetPosition;

    private void Awake()
    {
        if (!_player)
        {
<<<<<<< HEAD
            _player = FindObjectOfType<Player>();
=======
            _player = FindObjectOfType<Player>(); //ahahaha
>>>>>>> dev
        }
    }

    private void Update()
    {
        _targetPosition = _player.transform.position;
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + 4.0f, -10.0f);

        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime);
    }
}
