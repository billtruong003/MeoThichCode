using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(0, 10)]
    private float maxSpeed = 10f;

    [SerializeField, Range(0, 100)]
    private float maxAcceleration = 10;
    Rigidbody body;
    Vector3 velocity, desiredVelocity;
    bool desiredJump;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);


        desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;

        desiredJump = Input.GetButton("Jump");
        if (desiredJump)
        {
            Jump();
            desiredJump = false;
        }
    }

    void FixedUpdate()
    {
        velocity = body.velocity;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

        body.velocity = velocity;
    }

    void Jump()
    {
        body.velocity += Vector3.up * 5f;
    }
}
