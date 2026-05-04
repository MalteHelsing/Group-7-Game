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

    [Header("Bools")]
    [SerializeField] bool isActive = false;
    [SerializeField] bool hasSpear;
    [SerializeField] bool canAttack = false;


    InputAction attackAction;

    public void Start()
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
        if (attackAction.IsPressed() && hasSpear == true && isActive == false && canAttack == true)
        {
            StartCoroutine(DelayAction(spearDeActiveDelay));
            canAttack = false;
            spear.SetActive(!isActive);
        }
    }

    IEnumerator DelayAction(float spearDeActiveDelay)
    { 
        yield return new WaitForSeconds(spearDeActiveDelay);
        spear.SetActive(isActive);
        canAttack = true;
    }
}