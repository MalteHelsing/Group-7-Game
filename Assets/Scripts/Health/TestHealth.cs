using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestHealth : MonoBehaviour
{
    public int health = 5;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5; 

    void Update()
    {
        if (health >= 3)
        {

        }
        else if (health == 2)
        {

        }
        else if (health == 1)
        {

        }
        else if (health <= 0)
        {

        }
    }


}