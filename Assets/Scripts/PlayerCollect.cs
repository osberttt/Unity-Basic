using System;
using UnityEngine;
using TMPro;

public class PlayerCollect : MonoBehaviour
{
    public int fruitsCollected = 0;

   
    public AudioClip collectClip;
    
    public TextMeshProUGUI fruitsText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Fruit")) return;

        fruitsCollected++;
        fruitsText.text = fruitsCollected.ToString();
        
        Destroy(other.gameObject);
        
        // play collect-sfx
        AudioManager.Instance.PlaySFX(collectClip);
        
    }
}
