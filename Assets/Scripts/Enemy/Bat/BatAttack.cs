using System;
using Unity.VisualScripting;
using UnityEngine;

public class BatAtatck : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform[] attackWayPoints;

    [SerializeField] float iGAYRange = 5f;
    int attackPointIndex = 0;


    void Start()
    {

    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < iGAYRange)
        {
            //graah Im Gonna Attack You graaaaahhhh
            if (attackPointIndex < attackWayPoints.Length)
            {
                //now i gon aa ttack y uo
                
            }
        }
    }
}
