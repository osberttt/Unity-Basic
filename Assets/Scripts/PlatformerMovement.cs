using System;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    protected Animator _animator;
    protected PlayerLife _playerLife;
    
    public Transform groundChecker;
    public LayerMask groundLayer;

    public ParticleSystem footstepsParticles;

    public float radius = 0.2f;
    
    public float speed = 5f;
    public float jumpForce = 5f;

    protected float _horizontal;

    protected bool _jumpToConsume;

    protected int _jumps;

    private bool _isFacingRight = true;

    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerLife = GetComponent<PlayerLife>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    public virtual void Update()
    {
        if (!_playerLife.isAlive) return;
        _horizontal = Input.GetAxis("Horizontal");

        if (IsGrounded())
        {
            _jumps = 0;
        }
        
        if (_jumps < 1 && Input.GetKeyDown(KeyCode.Space))
        {
            _jumpToConsume = true;
        }

        FlipPlayer();
        UpdateAnimation();
    }

    void FixedUpdate()
    {
        if (!_playerLife.isAlive) return;
        _rb.linearVelocity = new Vector2(_horizontal * speed , _rb.linearVelocity.y);
        
        if (_jumpToConsume)
        {
            ExecuteJump();
        }
        
    }

    protected void FlipPlayer()
    {
        if (_rb.linearVelocity.x > 0)
        {
            if (!_isFacingRight)
            {
                footstepsParticles.Play();
            }
            transform.localScale = new Vector3(1,1,1);
            _isFacingRight = true;
        }

        if (_rb.linearVelocity.x < 0)
        {
            if (_isFacingRight)
            {
                footstepsParticles.Play();
            }
            transform.localScale = new Vector3(-1, 1, 1);
            _isFacingRight = false;
        }
    }
    
    protected virtual void UpdateAnimation()
    {
        if (_rb.linearVelocity.x == 0)
        {
            _animator.SetBool("isRunning", false);
        }
        else
        {
            _animator.SetBool("isRunning", true);
        }

        if (_rb.linearVelocity.y == 0 && IsGrounded())
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isFalling", false);
        }
        
        if (_rb.linearVelocity.y > 0 && !IsGrounded())
        {
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isFalling", false);
        }

        if (_rb.linearVelocity.y < 0 && !IsGrounded())
        {
            _animator.SetBool("isFalling", true);
            _animator.SetBool("isJumping", false);
        }
    }
    
    void ExecuteJump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
        footstepsParticles.Play();
        _jumps = _jumps + 1;
        _jumpToConsume = false;
    }

    protected bool IsGrounded()
    {
        bool groundCheck = Physics2D.OverlapCircle(groundChecker.position, radius, groundLayer);
        return groundCheck;
    }
    
    // reverse engineering
}
