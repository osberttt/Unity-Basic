using UnityEngine;

public class Script1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var x = 8;
        var y = 7;
        var z = 4;

        if (x < y)
        {
            Debug.Log("If block is run");
        }
        else if (x > z)
        {
            Debug.Log("Else If block is run");
        }
        else if (x < y)
        {
            Debug.Log("Else If block is run");
        }
        else
        {
            Debug.Log("Else block is run");
        }
        
        Debug.Log("Everything's completed");
    }
    
}
