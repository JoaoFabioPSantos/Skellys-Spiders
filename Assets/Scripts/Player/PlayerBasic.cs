using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.VFX;

public class PlayerBasic : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;

    [Header("Move config")]
    public SOPlayerBasicSetup SOPlayer;

    private float _currentSpeed;
    private bool _isJumping;

    [Header("Jump settings")]
    public Collider2D collider2D;
    public float distToGround;
    public float spaceToGround = .3f;
    public ParticleSystem jumpVFX;
    public AudioSource jumpAudio;

    private void Awake()
    {
        if (collider2D != null)
        {
            distToGround = collider2D.bounds.extents.y;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = SOPlayer.speedRun;
            animator.SetBool("isDashingRun", true);
        }
        else if (!Input.anyKey)
        {
            SOPlayer.friction = new Vector2(1f, 0);
        }
        else
        { 
            _currentSpeed = SOPlayer.speed;
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
            animator.SetBool("isMove", true);
            if (rb.transform.localScale.x >= -1)
            {
                rb.transform.DOScaleX(1, SOPlayer.playerSwapduration);
            }

        }
        else if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
            animator.SetBool("isMove", true);
            rb.transform.DOScaleX(-1, SOPlayer.playerSwapduration);
            if (rb.transform.localScale.x <= 1)
            {
                rb.transform.DOScaleX(-1, SOPlayer.playerSwapduration);
            }
        }
        else
        {
            animator.SetBool("isMove", false);
            animator.SetBool("isDashingRun", false);
        }


        if (rb.velocity.x < 0)
        {
            rb.velocity += SOPlayer.friction;
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity -= SOPlayer.friction;
        }

        
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector2.up * SOPlayer.forceJump;
            PlayJumpVFX();
            PlayJumpAudio();
        }

        if (rb.velocity.y != 0)
        {
            animator.SetBool("isJump", true);
            animator.SetBool("isDashingRun", false);
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
    private void PlayJumpVFX()
    {
        if(jumpVFX != null) jumpVFX.Play();
    }
    
    private void PlayJumpAudio()
    {
        if(jumpAudio != null) jumpAudio.Play();
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
