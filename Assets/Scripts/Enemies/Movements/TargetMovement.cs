using UnityEngine;
using Zenject;

public class TargetMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delayDuration;

    [Range(5, 10)]
    [SerializeField] private float _targetOffsetY;

    private void Start()
    {
        _targetOffsetY = Random.Range(3, _targetOffsetY);
    }

    public void Move()
    {
        
    }

    public void Move(Player target)
    {
        Vector3 _targetPosition = target.transform.position;

        transform.position = Vector3.MoveTowards
        (
            transform.position, 
            new Vector3(_targetPosition.x, _targetPosition.y + _targetOffsetY, 0), 
            _speed * Time.deltaTime
        );
    }
}