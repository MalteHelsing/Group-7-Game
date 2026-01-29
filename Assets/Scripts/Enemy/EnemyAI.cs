using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] bool isIntelligent = false;
    // isIntelligent does nothing right now, will add a function later
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float agroRange;

    Rigidbody2D EnemyRigidbody;

    private void Start()
    {
        EnemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        int layerIndex = LayerMask.NameToLayer("Wall");

        if (other.gameObject.layer == layerIndex)
        {
            transform.Rotate(0, 180, 0);
            Debug.Log("Hit wall");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
