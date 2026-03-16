using UnityEngine;

public class BossMovement : MonoBehaviour
{
    Transform[] waypoints;
    int waypointIndex = 0;
    float w;

    WaveConfig waveConfig;

    void Start()
    {
        //waypoints =
        //transform.position =
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Length)
        {
            Vector3 targetPostion = waypoints[waypointIndex].position;
            float moveDelta = w * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPostion, moveDelta);

            if (transform.position == targetPostion)
            {
                waypointIndex++;
            }
        }
    }

}
