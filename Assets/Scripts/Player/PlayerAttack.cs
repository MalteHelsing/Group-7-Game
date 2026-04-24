using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject spear;
    [SerializeField] GameObject PlacedSpear;
    [SerializeField] float SpearDeActiveDelay = 1.0f;
    [Header("Bools")]
    [SerializeField] bool isActive = true;
    [SerializeField] bool hasSpear = false;
    [SerializeFeild] bool canAttack = true;

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
        CheckScene();
        CheckIfAttack();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex = LayerMask.NameToLayer("Spear");

        if (other.gameObject.layer == layerIndex)
        {
            hasSpear = true;
            GameObject.Destroy(PlacedSpear);
        }
    }

    void CheckScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex >= 3)
        {
            hasSpear = true;
        }
    }

    void CheckIfAttack()
    {
        if (isActive == true)
        {
            canAttack = false;
        }
        else
        {
            canAttack = true;
        }
    }

    public void SpearAttack()
    {
        if (attackAction.WasPressedThisFrame() && hasSpear == true && canAttack == true)
        {
            if (isActive == false)
            {
                spear.SetActive(!isActive);
                StartCoroutine(DelayAction(SpearDeActiveDelay));
                canAttack = true;
            }
        }
    }

    IEnumerator DelayAction(float SpearDeActiveDelay)
    {
        yield return new WaitForSeconds(SpearDeActiveDelay);

        spear.SetActive(isActive);
    }
}