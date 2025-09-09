using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public bool isAlive = true;

    public int hp = 5;

    public float jumpForce = 7f;
    public float respawnDelay = 5f;
    public float flashTime = 1f;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _col;
    private Animator _anim;
    private SpriteRenderer _sr;
    

    public CinemachineCamera camera;
    public Transform checkpoint;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public GameObject hpBar;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var children = hpBar.GetComponentsInChildren<Transform>();
        
        foreach (var child in children)
        {
            child.gameObject.SetActive(false);
        }

        for (var i = 0; i <= hp; i++)
        {
            if (children.Length > i)
            {
                children[i].gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            hp--;
            StartCoroutine(FlashPlayer());
            if (hp == 0)
            {
                Die();
            } 
        }

        if (other.CompareTag("Finish"))
        {
            victoryPanel.SetActive(true);
        }
    }

    private IEnumerator FlashPlayer()
    {
        _sr.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        _sr.color = Color.white;
    }
    
    private void Die()
    {
        gameOverPanel.SetActive(true);
        isAlive = false;
        _rb.linearVelocity = new Vector2(0, jumpForce);
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
