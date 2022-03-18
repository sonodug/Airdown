using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _tapEvadeForce;

    private Vector3 _movementVector
    {
        get
        {
            float directionX = Input.GetAxis("Horizontal");
            float directionY = Input.GetAxis("Vertical");

            return new Vector3(directionX, directionY, 0.0f);
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _movementVector, _moveSpeed * Time.deltaTime);
    }
}
