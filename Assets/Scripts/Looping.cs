using System;
using UnityEngine;

public class Looping : MonoBehaviour
{
    public int[] numbers;

    private void Start()
    {
        
    }

    private void WhileLoop()
    {
        var i = 0;
        while (i < numbers.Length)
        {
            Debug.Log(numbers[i]);
            i++;
        }
        Debug.Log("Finished");
    }

    private void ForLoop()
    {
        for (var i = 0; i < numbers.Length; i++)
        {
            Debug.Log(numbers[i]);
        }
        Debug.Log("Finished");
    }

    private void ForEachLoop()
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }
}
