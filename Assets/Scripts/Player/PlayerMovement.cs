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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
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

    public void MoveBound()
    {
        // Empty for temporary
    }
}