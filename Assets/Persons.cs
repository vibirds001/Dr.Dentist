using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Person
{
    public GameObject person;
    public float seconds;
    public GameObject[] teeth;
}

public class Persons : MonoBehaviour
{
    public static Persons instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public Person[] person;

    public int minPrice;
    public int maxPrice;
}
