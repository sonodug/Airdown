using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
<<<<<<< HEAD
=======
    [SerializeField] private float _speed;

    [Range(3, 7)]
    [SerializeField] private float _targetOffsetY;

>>>>>>> dev
    private Enemy _enemy;

    private void Start()
    {
<<<<<<< HEAD
        
=======
        _enemy = GetComponent<Enemy>();
        _targetOffsetY = Random.Range(3, _targetOffsetY);
>>>>>>> dev
    }

    private void Update()
    {
<<<<<<< HEAD
        
=======
        Vector3 _targetPosition = _enemy.Target.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_targetPosition.x, _targetPosition.y + _targetOffsetY, 0), _speed * Time.deltaTime);
>>>>>>> dev
    }
}
