using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] Transform[] targetPoints;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float stopDuration = 1.5f;
    [SerializeField] float sweepDistance = 10.5f;
    [SerializeField] private float hitTimeWindow = 5f;

    private bool wasHitThisCycle = false;
    private BossState currentState = BossState.Wave1;

    private void Start()
    {
        StartCoroutine(BossLoop());
    }

    #region Wave 1
    public enum BossState
    {
        Wave1,
        Wave2
    }

    IEnumerator BossLoop()
    {
        while (true)
        {
            switch (currentState)
            {
                case BossState.Wave1:
                    yield return StartCoroutine(Wave1());
                    break;

                case BossState.Wave2:
                    yield return StartCoroutine(Wave2());
                    yield break; 
            }
        }
    }

    IEnumerator Wave1()
    {
        wasHitThisCycle = false;
        for (int i = 0; i < 3; i++)
        {
            Transform target = targetPoints[Random.Range(0, targetPoints.Length)];

            Vector2 center = target.position;

            Vector2 leftPos = center + Vector2.left * sweepDistance;
            Vector2 rightPos = center + Vector2.right * sweepDistance;

            yield return StartCoroutine(MoveToPosition(leftPos));

            yield return StartCoroutine(MoveToPosition(rightPos));

            yield return new WaitForSeconds(stopDuration);
        }

        float timer = 0f;

        while (timer < hitTimeWindow)
        {
            if (wasHitThisCycle)
            {
                currentState = BossState.Wave2;
                yield break;
            }

            timer += Time.deltaTime;
            yield return null;
        }

        currentState = BossState.Wave1;
    }

    IEnumerator Wave2()
    {
        Debug.Log("Wave 2 started!");

        // TODO: your second attack pattern here
        yield return null;
    }


    IEnumerator MoveToPosition(Vector2 target)
    {
        Vector2 start = transform.position;

        float distance = Vector2.Distance(start, target);
        float duration = distance / moveSpeed;

        float time = 0;

        while (time < duration)
        {
            float t = time / duration;

            t = 1 - Mathf.Pow(1 - t, 3);

            transform.position = Vector2.Lerp(start, target, t);

            time += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
    #endregion

    public void TakeHit()
    {
        wasHitThisCycle = true;
    }
}
