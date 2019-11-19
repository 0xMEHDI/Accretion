using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsHandler
{
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float maxSpeed = 5.0f;

    SpriteRenderer spriteRender;
    Animator animator;

    void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpForce;
        }

        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > Mathf.Epsilon)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRender.flipX ? (move.x > Mathf.Epsilon) : (move.x < -Mathf.Epsilon));
        if (flipSprite)
        {
            spriteRender.flipX = !spriteRender.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}
