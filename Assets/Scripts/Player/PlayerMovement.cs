using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _clampX;

    private Vector3 _movementVector
    {
        get
        {
            float directionX = Input.GetAxisRaw("Horizontal");

            return new Vector3(directionX, 0.0f, 0.0f);
        }
    }

    private void Update()
    {
        if(!PauseControl.GameIsPaused)
            Move();
    }

    private void Move()
    {
        Vector3 clampedTargetPosition = transform.position;
        clampedTargetPosition.x = Mathf.Clamp(clampedTargetPosition.x + _movementVector.x, -_clampX, _clampX);
        transform.position = Vector3.MoveTowards(transform.position, clampedTargetPosition, _moveSpeed * Time.deltaTime);
    }
}
