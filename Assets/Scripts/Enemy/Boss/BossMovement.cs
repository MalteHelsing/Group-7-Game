using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BossMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float hitWindow1 = 5f;
    [SerializeField] float hitWindow2 = 5f;
    [SerializeField] float hitWindow3 = 5f;

    [Header("Wave 1")]
    [SerializeField] private GameObject hand;
    [SerializeField] private LineRenderer armLine;
    [SerializeField] private Transform[] wave1TargetPos;
    [SerializeField] float stopDuration = 1.5f;
    [SerializeField] float sweepDistance = 10.5f;

    [Header("Wave 2")]
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;

    [SerializeField] private Transform[] leftPositions;
    [SerializeField] private Transform[] rightPositions;

    [SerializeField] private int wave2Repetitions = 3;
    [SerializeField] private float wave2WaitTime = 1.5f;

    private bool damageWindowActive = false;
    private bool wasHitThisCycle = false;
    [SerializeField] private BossState currentState = BossState.Wave1;

    private void Start()
    {
        StartCoroutine(BossLoop());
        hand.SetActive(true);
    }

    public enum BossState
    {
        Wave1,
        Wave2,
        Wave3
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
                    break;

                case BossState.Wave3:
                    yield return StartCoroutine(Wave3());
                    break;
            }

            yield return null;
        }
    }

    #region Wave 1
    IEnumerator Wave1()
    {
        SetHandActive(true);
        wasHitThisCycle = false;
        for (int i = 0; i < 3; i++)
        {
            Transform target = wave1TargetPos[Random.Range(0, wave1TargetPos.Length)];

            Vector2 center = target.position;

            Vector2 leftPos = center + Vector2.left * sweepDistance;
            Vector2 rightPos = center + Vector2.right * sweepDistance;

            yield return StartCoroutine(MoveToPosition(hand.transform, leftPos));
            yield return StartCoroutine(MoveToPosition(hand.transform, rightPos));

            yield return new WaitForSeconds(stopDuration);
        }

        damageWindowActive = true;
        float timer = 0f;

        while (timer < hitWindow1)
        {
            if (wasHitThisCycle)
            {
                damageWindowActive = false;

                hand.SetActive(false); 

                currentState = BossState.Wave2;
                yield break;
            }

            timer += Time.deltaTime;
            yield return null;
        }

        damageWindowActive = false;
        currentState = BossState.Wave1;
    }

    IEnumerator MoveToPosition(Transform obj, Vector2 target)
    {
        Vector2 start = obj.position;

        float distance = Vector2.Distance(start, target);
        float duration = distance / moveSpeed;

        float time = 0;

        while (time < duration)
        {
            float t = time / duration;
            t = 1 - Mathf.Pow(1 - t, 3);

            obj.position = Vector2.Lerp(start, target, t);

            time += Time.deltaTime;
            yield return null;
        }

        obj.position = target;
    }
    #endregion
    #region Wave 2
    IEnumerator Wave2()
    {
        SetHandActive(false);
        wasHitThisCycle = false;

        while (!wasHitThisCycle)
        {
            for (int i = 0; i < wave2Repetitions; i++)
            {
                yield return StartCoroutine(MoveHands(leftPositions[1].position, rightPositions[1].position));
                yield return new WaitForSeconds(wave2WaitTime);

                yield return StartCoroutine(MoveHands(leftPositions[2].position, rightPositions[2].position));
                yield return new WaitForSeconds(wave2WaitTime);

                yield return StartCoroutine(MoveHands(leftPositions[3].position, rightPositions[3].position));
                yield return new WaitForSeconds(wave2WaitTime);
            }

            damageWindowActive = true;

            float timer = 0f;

            while (timer < hitWindow2)
            {
                if (wasHitThisCycle)
                {
                    damageWindowActive = false;
                    currentState = BossState.Wave3;
                    yield break;
                }

                timer += Time.deltaTime;
                yield return null;
            }

            damageWindowActive = false;
        }
    }

    IEnumerator MoveHands(Vector2 leftTarget, Vector2 rightTarget)
    {
        while (Vector2.Distance(leftHand.position, leftTarget) > 0.05f ||
               Vector2.Distance(rightHand.position, rightTarget) > 0.05f)
        {
            leftHand.position = Vector2.MoveTowards(
                current: leftHand.position,
                target: leftTarget,
                maxDistanceDelta: moveSpeed * Time.deltaTime
            );

            rightHand.position = Vector2.MoveTowards(
                current: rightHand.position,
                target: rightTarget,
                maxDistanceDelta: moveSpeed * Time.deltaTime
            );

            yield return null;
        }
    }

    #endregion
    #region Wave 3
    IEnumerator Wave3()
    {
        Debug.Log("Wave 3 started!");
        yield break;
    }

    #endregion
    #region Remove this before making a build
    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            SetWave(BossState.Wave1);

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            SetWave(BossState.Wave2);

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            SetWave(BossState.Wave3);
    }

    public void SetWave(BossState newState)
    {
        StopAllCoroutines();
        currentState = newState;
        StartCoroutine(BossLoop());
    }
    #endregion

    void SetHandActive(bool active)
    {
        hand.SetActive(active);

        if (armLine != null)
            armLine.enabled = active;
    }

    public void TakeHit()
    {
        if (!damageWindowActive)
            return;

        wasHitThisCycle = true;
    }
}