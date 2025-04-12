using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;

    [Header("Move config")]
    public float speed;
    public float speedRun;
    public Vector2 friction = new Vector2(.1f, 0);
    public float forceJump = 2f;

    private float _currentSpeed;
    private bool _isJumping;

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void FixedUpdate()
    {


    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }
        else if (!Input.anyKey)
        {
            friction = new Vector2(1f, 0);
        }
        else
        {
            _currentSpeed = speed;
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
            sr.flipX = false;
            animator.SetBool("isMove", true);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
            sr.flipX = true;
            animator.SetBool("isMove", true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }


        if (rb.velocity.x < 0)
        {
            rb.velocity += friction;
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity -= friction;
        }

        
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * forceJump;
        }

        if (rb.velocity.y != 0)
        {
            animator.SetBool("isJump", true);
            _isJumping = true;
        }
        else if (rb.velocity.y == 0f && _isJumping)
        {
            animator.Play("PlayerSmol");
            _isJumping = false;
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }
}
