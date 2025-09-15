using System;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(f(5));
    }

    public void Walk()
    {
        
    }

    public void SwordAttack()
    {
        
    }
    public virtual int f(int x)
    {
        return x + 2;
    }
}