using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject spear;
    [SerializeField] GameManager spearLooker;
    [SerializeField] bool isActive = true;
    [SerializeField] bool isSpear = true;
    [SerializeField] float SpearDeActiveDelay = 1.0f;


    InputAction attackAction;
    Rigidbody2D rb2d;

    private void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");

        spear.SetActive(isActive);
    }

    private void Update()
    {
        if (attackAction.WasPressedThisFrame())
        { 
            if (isActive == false && isSpear == true)
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