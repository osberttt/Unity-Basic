using UnityEngine;

public class CSharpPractice : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var a = f(2,3);
        Debug.Log(a);
    }

    // function declaration
    int f(int x, int y) 
    {
        return x + y;
    }
}
