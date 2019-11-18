using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    [SerializeField] float maxSpeed = 3f;
    [SerializeField] float jumpForce = 150f;
    [SerializeField] float maxForce = 2f;

    Rigidbody2D rigidBody;
    bool isGrounded;

    void Start()
    {              
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        ProcessHorizontalMovement();
        ProcessVerticalMovement();
    }

    private void ProcessHorizontalMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rigidBody.AddForce(Vector2.right * horizontal * speed);

        if (rigidBody.velocity.x > maxSpeed)
        {
            rigidBody.velocity = new Vector2(maxSpeed, rigidBody.velocity.y);
            transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
        }

        if (rigidBody.velocity.x < -maxSpeed)
        {
            rigidBody.velocity = new Vector2(-maxSpeed, rigidBody.velocity.y);
            transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
        }
    }

    private void ProcessVerticalMovement()
    {
        float jump = Input.GetAxisRaw("Jump");
        if (isGrounded)
        {
            rigidBody.AddForce(Vector2.up * jump * jumpForce);
            if (rigidBody.velocity.y > maxForce)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, maxForce);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
