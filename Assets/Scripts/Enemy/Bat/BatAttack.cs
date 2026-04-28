using System;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class BatAtatck : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform[] attackWayPoints;

    [SerializeField] float attackSpeed = 5f;
    [SerializeField] float iGAYRange = 5f;
    int attackPointIndex = 0;


    void Start()
    {

    }

    void Update()
    {
        batAttackCheck();

        Task.Delay(5);
    }

    void batAttackCheck()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < iGAYRange && distToPlayer > iGAYRange - 1)
        {
            //graah Im Gonna Attack You graaaaahhhh
            if (attackPointIndex < attackWayPoints.Length)
            {
                //now i gon aa ttack y uo
                Vector3 targetPosition = attackWayPoints[attackPointIndex].position;
                float moveDelta = attackSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveDelta);

                if (transform.position == targetPosition)
                {
                    attackPointIndex++;
                }
                if (attackPointIndex == attackWayPoints.Length)
                {
                    attackPointIndex = 0;
                }
            }
        }
    }

}
