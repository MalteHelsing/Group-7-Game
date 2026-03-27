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
       
        testHealth.DamageTaken += UpdateHearts;
        for(int i = 0; i < testHealth.maxHealth; i++)
        {
            GameObject h = Instantiate(heart, this.transform);
            hearts.Add(h.GetComponent<Image>());
        }
    }

   void UpdateHearts()
    {
        int heartContainer = testHealth.Health; 

        foreach(Image i in hearts)
        {
            i.fillAmount = heartContainer;
            heartContainer -= 1;
        }
    }
}
