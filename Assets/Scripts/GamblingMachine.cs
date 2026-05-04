using UnityEngine;

public class GamblingMachine : MonoBehaviour
{
    [System.Serializable]
    public class SlotSymbol
    {
        public Sprite sprites;
        public int value;
    }

    [SerializeFeild] public SlotSymbol[] symbols;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float target = 1f;

    Sprite[] sprites;
    private SpriteRenderer rend;
    private int spriteIndex;


    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = sprites[100];
        InvokeRepeating(nameof(AnimateSprite), 0.15f, speed);
        Spin();
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

    private void FixedUpdate()
    {
        speed += (target - speed) * 0.1f;
    }

    void Spin()
    {
        SlotSymbol s1 = symbols[Random.Range(0, symbols.Length)];
        SlotSymbol s2 = symbols[Random.Range(0, symbols.Length)];
        SlotSymbol s3 = symbols[Random.Range(0, symbols.Length)];

        int totalValue = s1.value + s2.value + s3.value;
    }
}