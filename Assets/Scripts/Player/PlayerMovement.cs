using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 maxSpeed;
    public Vector2 timeToFullSpeed;
    public Vector2 timeToStop;
    public Vector2 stopClamp;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;

    private float xMin, xMax, yMin, yMax; // Movement bounds

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }

    void Update()
    {
        UpdateCameraBounds(); // Update camera bounds for every frame size
    }

    public void Move()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector2 targetVelocity = moveDirection * moveVelocity;
        Vector2 friction = GetFriction();
        targetVelocity += friction * Time.fixedDeltaTime;

        float clampedX = Mathf.Clamp(targetVelocity.x, -maxSpeed.x, maxSpeed.x);
        float clampedY = Mathf.Clamp(targetVelocity.y, -maxSpeed.y, maxSpeed.y);
        rb.velocity = new Vector2(clampedX, clampedY);

        if (Mathf.Abs(rb.velocity.x) < stopClamp.x && Mathf.Abs(rb.velocity.y) < stopClamp.y)
        {
            rb.velocity = Vector2.zero;
        }

        MoveBound();
    }

    public bool IsMoving()
    {
        return rb.velocity.magnitude > 0.1f;
    }

    private Vector2 GetFriction()
    {
        if (moveDirection.magnitude > 0)
        {
            return moveFriction;
        }
        else
        {
            return stopFriction;
        }
    }

    private void UpdateCameraBounds()
    {
        Camera camera = Camera.main;

        float distanceToCamera = Mathf.Abs(camera.transform.position.z - transform.position.z);

        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, distanceToCamera));

        xMin = bottomLeft.x + 0.2f;
        yMin = bottomLeft.y;
        xMax = topRight.x - 0.2f;
        yMax = topRight.y - 0.5f;
    }

    public void MoveBound()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, xMin, xMax);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, yMin, yMax);
        transform.position = clampedPosition;
    }
}