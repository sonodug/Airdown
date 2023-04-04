using UnityEngine;
using Zenject;

public class TargetMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
    
    [SerializeField] private float _delayDurationRange;

    [Range(5, 10)]
    [SerializeField] private float _targetOffsetY;

    private Player _target;
    private float _delayTimer;
    private float _betweenDelayTimer;
    private bool _isDelaying;
    private float _randomOffsetY;

    private enum State
    {
        PositionMove,
        FollowingTarget
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
        switch (_currentState)
        {
            case State.PositionMove:
                HandlePositionMoveState();
                break;
            case State.FollowingTarget:
                HandleMoveTowardsTarget();
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
}