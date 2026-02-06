using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] bool isActive = false;

    [SerializeField] float TimeSpearDoesDamage = 1f;

    private void Update()
    {
        if (Keyboard.current.eKey.isPressed)
        {
            StartCoroutine (TimeHitbox());
        }
        else
        {
            gameObject.SetActive(isActive);
        }
    }

    private IEnumerator TimeHitbox()
    {
        gameObject.SetActive(!isActive);
        yield return new WaitForSeconds(TimeSpearDoesDamage);
    }

}
