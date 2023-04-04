using UnityEngine;

public class PointMovement : MonoBehaviour, IMovable
{
    [SerializeField] private Vector3 _pointPosition;
    [SerializeField] private float _speed;

    private bool _isPointReached = false;

    public void Move()
    {
        if (!_isPointReached)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointPosition, _speed * Time.deltaTime);
            _isPointReached = true;
        }
    }

    public void Move(Player target) { }
}