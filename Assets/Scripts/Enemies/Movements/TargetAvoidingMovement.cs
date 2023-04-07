using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetAvoidingMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _avoidRayDistance;
    [SerializeField] private float _avoidProbability;
    [SerializeField] private float _avoidSpeed;
    [SerializeField] private float _avoidMoveDistance;
    [SerializeField] private LayerMask _layerMask;
    
    [SerializeField] private float _delayDurationRange;

    [Range(5, 10)]
    [SerializeField] private float _targetOffsetY;

    private Player _target;
    private float _delayTimer;
    private float _betweenDelayTimer;
    private bool _isDelaying;
    private float _randomOffsetY;
    private bool _raycastEnabled = true;
    private int _currentAvoidDirection;
    private Vector3 _targetAvoidPosition;

    private enum State
    {
        PositionMove,
        FollowingTarget,
        AvoidRocket
    }

    private State _currentState;

    private void Start()
    {
        _targetOffsetY = Random.Range(3, _targetOffsetY);
        _randomOffsetY = Random.Range(-2, 2);
        _currentState = State.PositionMove;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, _avoidRayDistance, _layerMask);

        if (hit.collider != null && _raycastEnabled)
        {
            if (Random.Range(0, 100) <= _avoidProbability * 100)
            {
                _currentState = State.AvoidRocket;
                
                if (transform.position.x < 0.0f)
                    _currentAvoidDirection = 1;
                else if (transform.position.x > 0.0f)
                    _currentAvoidDirection = -1;
                
                _targetAvoidPosition = new Vector3(transform.position.x + _avoidMoveDistance * _currentAvoidDirection, transform.position.y, 0.0f);
                _raycastEnabled = false;
            }
            else
                _raycastEnabled = false;
        }
        else if (!hit.collider)
        {
            _raycastEnabled = true;
        }
        
        switch (_currentState)
        {
            case State.PositionMove:
                HandlePositionMoveState();
                break;
            case State.FollowingTarget:
                HandleMoveTowardsTarget();
                break;
            case State.AvoidRocket:
                HandleAvoidMovementState(_currentAvoidDirection, _targetAvoidPosition);
                break;
        }
    }

    private void HandleMoveTowardsTarget()
    {
        if (_isDelaying)
        {
            _delayTimer -= Time.deltaTime;
            if (_delayTimer <= 0)
            {
                _isDelaying = false;
                _randomOffsetY = Random.Range(-2, 2);
            }
        }

        if (!_isDelaying)
        {
            _betweenDelayTimer -= Time.deltaTime;
            if (_betweenDelayTimer <= 0)
            {
                _isDelaying = true;
                InitTimer();
            }
        }

        if (!_isDelaying)
        {
            Vector3 targetPosition = _target.transform.position;
            float offset = Mathf.Clamp(transform.position.y + _randomOffsetY, 3, _targetOffsetY - 2.0f);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition.x, offset, 0), _speed * Time.deltaTime);
        }
    }

    private void HandlePositionMoveState()
    {
        if (_target)
        {
            Vector3 targetPosition = _target.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition.x, targetPosition.y + _targetOffsetY, 0), _speed * Time.deltaTime);
            if (transform.position.y == targetPosition.y + _targetOffsetY)
            {
                _currentState = State.FollowingTarget;
                InitTimer();
            }
        }
    }

    private void HandleAvoidMovementState(int direction, Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _avoidSpeed * Time.deltaTime);

        if (transform.position.x == targetPosition.x)
        {
            _currentState = State.FollowingTarget;
        }
    }

    public void Move() {}

    public void Move(Player target)
    {
        _target = target;
        _currentState = State.PositionMove;
    }

    public void InitTimer()
    {
        _isDelaying = true;
        _delayTimer = Random.Range(0, _delayDurationRange);
        _betweenDelayTimer = Random.Range(1, 2);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = Vector3.down * _avoidRayDistance;
        if (_raycastEnabled)
            Gizmos.DrawRay(transform.position, direction);
    }
}