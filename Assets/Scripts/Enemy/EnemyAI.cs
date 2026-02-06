using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject Hitbox;
    [SerializeField] Transform player;

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float agroRange = 5f;

    

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroRange)
        {
            // Start chasing player
            ChasePlayer();
        }

        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }

    void ChasePlayer()
    {
        //rotate towards player
        if(transform.position.x < player.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        int layerIndexC = LayerMask.NameToLayer("Wall");

        if (other.gameObject.layer == layerIndexC)
        {
            transform.Rotate(0, 180, 0);
            Debug.Log("Hit wall");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }

}
