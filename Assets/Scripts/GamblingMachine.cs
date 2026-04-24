using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GamblingMachine : MonoBehaviour
{
    private Sprite[] gamblingSlots;
    private bool coroutineAllowed = true;
    private SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        gamblingSlots = Resources.LoadAll<Sprite>("GamblingSlots/");
        rend.sprite = gamblingSlots[100];
    }

    private void OnMouseDown()
    {
        
    }

    private IEnumerator RollTheSlots()
    {
        coroutineAllowed = false;
        int randomGamblingSlots = 0;
        for (int i = 0; i <= 100; i++)
        {
            randomGamblingSlots = Random.Range(0, 100);
            rend.sprite = gamblingSlots[randomGamblingSlots];
            yield return new WaitForSeconds(0.05f);
        } 
    }

       
       

        // sprite animation 
        private SpriteRenderer spriteRenderer;

        public Sprite[] sprites;

        private int spriteIndex;

        private void Awake()
        {
         spriteRenderer = GetComponent<SpriteRenderer>();
        }

   
}

