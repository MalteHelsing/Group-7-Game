using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GamblingMachine : MonoBehaviour
{
    private Sprite[] sprites;
    private bool coroutineAllowed = true;
    private SpriteRenderer rend;
    private int spriteIndex;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("GamblingSlots/");
        rend.sprite = sprites[100];
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private IEnumerator RollTheSlots()
    {
        coroutineAllowed = false;
        int randomGamblingSlots = 0;
        for (int i = 0; i <= 100; i++)
        {
            randomGamblingSlots = Random.Range(0, 100);
            rend.sprite = sprites[randomGamblingSlots];
            yield return new WaitForSeconds(0.05f);
        } 
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        rend.sprite = sprites[spriteIndex];
    }
}