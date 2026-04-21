using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject spear;
    [SerializeField] GameObject PlacedSpear;
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
        CheckScene();
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