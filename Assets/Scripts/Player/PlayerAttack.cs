using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public GameObject Spear;
    bool isAttacking = false;
    float atkDuration = 0.3f;
    float atkTimer = 0f;

    private void Update()
    {
        CheckSpearTimer();

        if (Keyboard.current.eKey.isPressed)
        {
            OnAttack();
        }
    }

    void OnAttack()
    {
        if (isAttacking)
        {
            Spear.SetActive(true);
            isAttacking = true;
        }
    }

    void CheckSpearTimer()
    {
        if (isAttacking)
        {
            atkTimer += Time.deltaTime;
            if(atkTimer >= atkDuration)
            {
                atkTimer = 0;
                isAttacking = false;
                Spear.SetActive(false);
            }

        }
    }
}