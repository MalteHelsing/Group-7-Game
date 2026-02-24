using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject spear;
    [SerializeField] bool isActive = true;
    [SerializeField] float SpearDeActiveDelay = 1.0f;

    private void Start()
    {
        spear.SetActive(isActive);
    }

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            StartCoroutine(DelayAction(SpearDeActiveDelay));
        }
    }

    IEnumerator DelayAction(float SpearDeActiveDelay)
    {
        spear.SetActive(!isActive);
        yield return new WaitForSeconds(SpearDeActiveDelay);
        spear.SetActive(isActive);
    }
}
