using UnityEngine;
using Zenject;

public class PlayerTracker : MonoBehaviour
{
    [Inject] private Player _player;
    
    [SerializeField] private float _trackSpeed;
    
    private Vector3 _targetPosition;

    private void Update()
    {
        _targetPosition = _player.transform.position;
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + 4.0f, -10.0f);

        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _trackSpeed);
    }
}
