using System;
using UnityEngine;

public class PointMovement : MonoBehaviour, IMovable
{
    [SerializeField] private Vector3 _targetPoint;
    [SerializeField] private float _speed;

    private bool _isPointReached = false;

    private void Update()
    {
        if (!_isPointReached)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);
            if (transform.position == _targetPoint)
                _isPointReached = true;
        }
    }

    public void Move() { }
    
    public void Move(Player target) { }
}