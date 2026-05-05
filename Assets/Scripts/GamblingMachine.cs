using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamblingMachine : MonoBehaviour
{
    [System.Serializable]
    public class SlotSymbol
    {
        public Sprite sprites;
        public int value;
    }

    [Header("Slot Value")]
    [SerializeField] public SlotSymbol[] symbols;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float target = 1f;

    [Header("Animation")]
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image[] slot;
    [HideInInspector] Sprite[] slotSymbol;
    
    private int spriteSlot;
    private bool isOn = false;

    private void Start()
    {
        slot[0] = GetComponent<Image>();
        slot[1] = GetComponent<Image>();
        slot[2] = GetComponent<Image>();
    }
    #region Animation
    public void StartSpinning()
    {
        StartCoroutine(Something());
    }

    private void AnimateSlot()
    {
        spriteSlot++;

        if (spriteSlot >= sprites.Length)
        {
            spriteSlot = 0;
        }

        slot[0].sprite = sprites[spriteSlot];
        slot[1].sprite = sprites[spriteSlot];
        slot[2].sprite = sprites[spriteSlot];
    }

    private void FixedUpdate()
    {
        if (isOn == true)
        {
            speed += (target - speed) * 0.1f;
        }
    }

    void Spin()
    {
        SlotSymbol s1 = symbols[Random.Range(0, symbols.Length)];
        SlotSymbol s2 = symbols[Random.Range(0, symbols.Length)];
        SlotSymbol s3 = symbols[Random.Range(0, symbols.Length)];

        int totalValue = s1.value + s2.value + s3.value;

        slotSymbol[0] = s1.sprites;
        slotSymbol[1] = s2.sprites;
        slotSymbol[2] = s3.sprites;
    }

    IEnumerator Something()
    {
        if (speed <= 1f)
        {
            isOn = true;
            InvokeRepeating(nameof(AnimateSlot), 0.15f, speed);
        }

        yield return new WaitForSeconds(1f);
        Spin();

        if (speed >= 1f)
        {
            isOn = false;
            CancelInvoke(nameof(AnimateSlot));
        }

        slot[0].sprite = slotSymbol[0];
        slot[1].sprite = slotSymbol[1];
        slot[2].sprite = slotSymbol[2];
    }
    #endregion
    #region Status Affects
    void StatusAffect()
    {
        
    }
    #endregion
}