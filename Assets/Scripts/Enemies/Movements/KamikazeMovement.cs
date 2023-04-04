using System;
using UnityEngine;

public class KamikazeMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    
    public void Move() { }

    public void Move(Player target)
    {
        Vector3 targetPosition = target.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        Vector3 targetDirection = targetPosition - transform.position;
        Debug.DrawRay(transform.position, targetDirection, Color.red);
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle + 90.0f, Vector3.forward), Time.deltaTime * _rotationSpeed);
    }
}