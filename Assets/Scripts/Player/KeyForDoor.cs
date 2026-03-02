using UnityEngine;

public class KeyForDoor : MonoBehaviour
{
    [Header("Key")]
    [SerializeField] float KeyPickUpDelay = 0.1f;

    bool HasKey = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key") && !HasKey)
        {
            HasKey = true;
            Destroy(other.gameObject, KeyPickUpDelay);
        }
        else if (other.CompareTag("Door") && HasKey)
        {
            HasKey = false;
            Debug.Log("Door OPEN");
        }
    }
}
