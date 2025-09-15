using UnityEngine;

public class Script2 : Script1
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Debug.Log(f(5));
    }

    public override int f(int x)
    {
        return x * 2;
    }
}
