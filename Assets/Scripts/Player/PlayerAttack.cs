using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] bool isActive = true;
    [SerializeField] float SpearDeActiveDelay = 1.0f;


    private void Start()
    {
        gameObject.SetActive(isActive);
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
        gameObject.SetActive(!isActive);
        yield return new WaitForSeconds(SpearDeActiveDelay);
        gameObject.SetActive(isActive);
    }
}
