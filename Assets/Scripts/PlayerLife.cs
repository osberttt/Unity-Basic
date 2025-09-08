using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public bool isAlive = true;

    public float jumpForce = 7f;
    public float respawnDelay = 5f;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _col;
    private Animator _anim;

    public CinemachineCamera camera;
    public Transform checkpoint;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Spike")) return;
        isAlive = false;
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
        _col.enabled = false;
        _anim.enabled = false;
        camera.Follow = null;
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(respawnDelay);
        isAlive = true;
        _rb.linearVelocity = new Vector2(0, 0);
        transform.position = checkpoint.position;
        _col.enabled = true;
        _anim.enabled = true;
        camera.Follow = transform;
    }
}
