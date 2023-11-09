using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpPipePair : PipePair
{
    enum Direction
    {
        Up,
        Down
    }

    [Header("JumpPipePair Settings")]
    [SerializeField]
    private float minHeight;
    [SerializeField]
    private float maxHeight;
    [SerializeField]
    private float speed;

    private Direction currentDirection;

    private Controls controls;

    protected override void OnAwake()
    {
        controls = new Controls();
        controls.Enable();
        controls.Bird.Jump.performed += Jump;

        currentDirection = Random.Range(0f, 1f) > 0.5f ? Direction.Up : Direction.Down;

        base.wonderPipe.BirdLocked.AddListener(OnWonderEnter);
    }

    private void OnWonderEnter()
    {
        controls.Disable();
        this.enabled = false;
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.Bird.Jump.performed -= Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        currentDirection = currentDirection == Direction.Down ? Direction.Up : Direction.Down;
    }

    protected override void OnUpdate()
    {
        if (currentDirection == Direction.Up)
        {
            if (transform.position.y < maxHeight)
            {
                transform.Translate(new Vector3(0, speed) * Time.deltaTime);
            }
            else
            {
                currentDirection = Direction.Down;
            }
        }

        if (currentDirection == Direction.Down)
        {
            if (transform.position.y > minHeight)
            {
                transform.Translate(new Vector3(0, -speed) * Time.deltaTime);
            }
            else
            {
                currentDirection = Direction.Up;
            }
        }
    }
}
