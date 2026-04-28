using UnityEngine;
using Random = UnityEngine.Random;
public class Test : MonoBehaviour
{
    [System.Serializable]
    public class SlotSymbol
    {
        public Sprite sprites;
        public int value;
    }

    [SerializeFeild] public SlotSymbol[] symbols;

    void Spin()
    {
        SlotSymbol s1 = symbols[Random.Range(0, symbols.Length)];
        SlotSymbol s2 = symbols[Random.Range(0, symbols.Length)];
        SlotSymbol s3 = symbols[Random.Range(0, symbols.Length)];

        int totalValue = s1.value + s2.value + s3.value;
    }
}
