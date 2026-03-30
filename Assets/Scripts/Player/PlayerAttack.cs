using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject spear;
    [SerializeField] bool isActive = true;
    [SerializeField] bool hasSpear = false;
    [SerializeField] float SpearDeActiveDelay = 1.0f;


    InputAction attackAction;
    Health health;

    private void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        spear.SetActive(isActive);
    }

    private void Update()
    {
        SpearAttack();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex = LayerMask.NameToLayer("Spear");

        if (other.gameObject.layer == layerIndex)
        {
            hasSpear = true;
        }
    }

    public void SpearAttack()
    {
        if (attackAction.WasPressedThisFrame() && hasSpear == true)
        {
            if (isActive == false)
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