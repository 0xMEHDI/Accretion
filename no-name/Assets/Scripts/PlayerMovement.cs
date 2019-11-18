using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 50f;

    PlayerController controller;
    Animator animator;

    float horizontal;
    bool jump;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontal, false, jump);
        jump = false;
    }
}
