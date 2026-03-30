using UnityEngine;

public class BatAtatck : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float batAttackSpeed = 5f;

    Rigidbody2D rb2d;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb2d.MovePosition(transform.position + direction * batAttackSpeed * Time.deltaTime);
    }
}
