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

    
    

    
}
