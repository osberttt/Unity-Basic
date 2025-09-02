using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector2(horizontal,vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
