using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : PhysicsHandler
{
    [SerializeField] float maxSpeed = 5.0f;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float knockbackForce = 100.0f;

    [SerializeField] int playerHealth = 3;

    Animator animator;

    Vector2 move;
    bool canMove = true;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    protected override void ComputeVelocity()
    {
        if (canMove)
        {
            move = Vector2.zero;
            move.x = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump") && grounded)
            {
                velocity.y = jumpForce;
            }

            else if (Input.GetButtonUp("Jump"))
            {
                if (velocity.y > Mathf.Epsilon)
                {
                    velocity.y *= 0.5f;
                }
            }

            targetVelocity = move * maxSpeed;
        }
        
        //TODO Refactor
        if (move.x > Mathf.Epsilon)
        {
            transform.localScale = new Vector2((Mathf.Abs(transform.localScale.x)), transform.localScale.y);
        }
        else if (move.x < -Mathf.Epsilon)
        {
            transform.localScale = new Vector2(-(Mathf.Abs(transform.localScale.x)), transform.localScale.y);
        }

        //TODO Refactor
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
    }

    //TODO Rework using PhysicsHandler behaviour
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (canMove)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Vector2 direction = (Vector2)(transform.position - collision.transform.position).normalized;
                Vector2 knockback = direction * knockbackForce * Time.fixedDeltaTime;
                rb2d.position += knockback;

                playerHealth--;
                if (playerHealth <= 0)
                {
                    canMove = false;
                    animator.SetBool("dead", true);
                    Invoke("StartDeathSequence", 3f);
                }
            }
        }
    }

    private void StartDeathSequence()
    {
        SceneManager.LoadScene(0);
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }
}
