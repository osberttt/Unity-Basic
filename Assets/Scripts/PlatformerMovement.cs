using System;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    
    public Transform groundChecker;
    public LayerMask groundLayer;

    public float radius = 0.2f;
    
    public float speed = 5f;
    public float jumpForce = 5f;

    private float _horizontal;

    private bool _jumpToConsume;

    private bool _isGrounded;

    private int _jumps;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if (IsGrounded())
        {
            _animator.SetBool("isGrounded", true);
            _jumps = 0;
        }
        
        if (_jumps < 1 && Input.GetKeyDown(KeyCode.Space))
        {
            _jumpToConsume = true;
        }
        
        //SetAnimation();
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_horizontal * speed , _rb.linearVelocity.y);
        
        if (_jumpToConsume)
        {
            ExecuteJump();
        }
        
    }

    void SetAnimation()
    {
        if (_rb.linearVelocity.x > -0.1f && _rb.linearVelocity.x < 0.1f) // x == 0
        {
            Debug.Log("Player Idle");
            _animator.Play("Player Idle");
        }

        if (_rb.linearVelocity.x < -0.1f && _rb.linearVelocity.x > 0.1f) // x != 0
        {
            Debug.Log("Player Run");
            _animator.Play("Player Run");
        }
    }
    void ExecuteJump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
        _jumps = _jumps + 1;
        _jumpToConsume = false;
    }

    bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundChecker.position, radius, groundLayer);
        return isGrounded;
    }
}
