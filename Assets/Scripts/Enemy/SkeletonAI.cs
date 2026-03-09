using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float agroRange = 5f;
    [SerializeField] float runRange = 2.5f;

    [SerializeField] bool isFacingRight = true;

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < runRange)
        {
            // Start running like a fucking coward, little baby, little fucking wah wah baby coward.
            Run();
        }
        if (distToPlayer < agroRange)
        {
            //SHOOT THAT MOTHERFUCKER!!!!'
            Aggro();
        }
    }

    void Run()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }

    void Aggro()
    {
        //rotate towards player
        if (transform.position.x < player.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFacingRight = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isFacingRight = false;
        }
    }

    //welcome to the underground!
    //how was the fall?
    //if you want to look around,
    //give us a call.
    //
}
