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
        if (isActive == false)
        {
            if (Mouse.current.leftButton.isPressed)
            { 
                spear.SetActive(!isActive);
                StartCoroutine(DelayAction(SpearDeActiveDelay));
            }
        }
    }

    IEnumerator DelayAction(float SpearDeActiveDelay)
    {
        yield return new WaitForSeconds(SpearDeActiveDelay);
        spear.SetActive(isActive);
    }
}