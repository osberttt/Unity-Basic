using System;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    private void Start()
    {
        var shweWar = new Cat("Shwe War", 1, "Yellow");
        Debug.Log(shweWar.age);
        shweWar.Meow();

        var day1 = Day.Monday;
        var day2 = "Tuesday";

        if (day1 == Day.Monday)
        {
            Debug.Log("go to work");
        }
    }

}

// struct
public struct Cat // stack
{
    public string name;
    public int age;
    public string color;

    // constructor
    public Cat(string name, int age, string color)
    {
        this.name = name;
        this.age = age;
        this.color = color;
    }
    public void Meow()
    {
        Debug.Log("Meow");
    }
}


// enum
public enum Day
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
}