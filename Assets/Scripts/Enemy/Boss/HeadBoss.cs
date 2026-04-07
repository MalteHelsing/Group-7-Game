using UnityEngine;

public class HeadBoss : MonoBehaviour
{
    BossMovement bossMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {       
        int layerIndexC = LayerMask.NameToLayer("HitBox");

        if (other.gameObject.layer == layerIndexC)
        {
            bossMovement.TakeHit();
        }
    }
}
