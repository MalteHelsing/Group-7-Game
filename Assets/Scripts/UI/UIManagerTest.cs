using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class UIManagerTest : MonoBehaviour
{
    public GameObject heart;
    public List<Image> hearts;

    TestHealth testHealth; 
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < testHealth.maxHealth; i++)
        {
            GameObject h = Instantiate(heart, this.transform);
            hearts.Add(h.GetComponent<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
