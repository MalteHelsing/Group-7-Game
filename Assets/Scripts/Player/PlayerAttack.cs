using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject spear;
    [SerializeField] GameObject PlacedSpear;
    [SerializeField] float spearDeActiveDelay = 1.0f;
    [SerializeField] float attackDelay = 1.0f;

    [Header("Bools")]
    [SerializeField] bool isActive = true;
    [SerializeField] bool hasSpear = false;
    private bool canAttack = true;

    InputAction attackAction;
    private void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        spear.SetActive(isActive);
    }

    private void Update()
    {
        CheckScene();
        SpearAttack();
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
        if (attackAction.IsPressed() && hasSpear == true && canAttack == true && isActive == false)
        {
            Attack();
        }
    }

    IEnumerator DelayAction(float spearDeActiveDelay)
    {

        yield return new WaitForSeconds(spearDeActiveDelay);
        spear.SetActive(isActive);
    }

    void Attack()
    {
        

        spear.SetActive(!isActive);
        canAttack = false;
        StartCoroutine(DelayAction(spearDeActiveDelay));

        canAttack = true;
    }
}