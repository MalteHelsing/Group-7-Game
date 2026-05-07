using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static GamblingMachine;

public class GamblingMachine : MonoBehaviour
{
    public enum PowerUpType
    {
        Speed,
        Health
    }

    [System.Serializable]
    public class SlotSymbol
    {
        public Sprite sprites;
        public int value;
    }

    [System.Serializable]
    public class RewardTier
    {
        public int minValue;
        public int maxValue;

        public Powerup powerUp;
    }

    [System.Serializable]
    public class Powerup
    {
        public string powerUpName;

        public PowerUpType type;
        
        public float amount;

        public string description;
        
        public Sprite powerupIcon;
    }

    [Header("Slot Value & Powerup Value")]
    [SerializeField] SlotSymbol[] symbols;
    [SerializeField] private RewardTier[] rewards;
    [SerializeField] private float speed = 0.1f;

    [Header("Animation")]
    [SerializeField] Image[] slot;
    [SerializeField] Sprite[] sprites;
    [HideInInspector] Sprite[] slotSymbol;
    private int[] spriteSlot = new int[3];

    [Header("Powerup Icon")]
    [SerializeField] private GameObject rewardIcon;
    [SerializeField] private TMP_Text rewardText;
    private SlotSymbol[] finalResults = new SlotSymbol[3];

    ButtonBehavior buttonBehavior;
    PlayerMovement player;
    Health playerHealth;

    InputAction interactAction;

    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");

        buttonBehavior = FindFirstObjectByType<ButtonBehavior>();

        slotSymbol = new Sprite[3];
    }

    private void Update()
    {
        OpenGamblingMachine();
    }
    #region Animation
    public IEnumerator StartSpinning()
    {
        StartCoroutine(SpinAnimation(0, 1f));
        StartCoroutine(SpinAnimation(1, 1.5f));
        StartCoroutine(SpinAnimation(2, 2f));

        yield return new WaitForSeconds(2.1f);

        Spin();
    }

    private void AnimateSlot(int slotIndex)
    {
        spriteSlot[slotIndex]++;

        if (spriteSlot[slotIndex] >= sprites.Length)
        {
            spriteSlot[slotIndex] = 0;
        }

        slot[slotIndex].sprite = sprites[spriteSlot[slotIndex]];
    }

    IEnumerator SpinAnimation(int slotIndex, float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            AnimateSlot(slotIndex);

            timer += Time.deltaTime;

            yield return new WaitForSeconds(speed);
        }

        SlotSymbol result = symbols[Random.Range(0, symbols.Length)];

        finalResults[slotIndex] = result;

        slot[slotIndex].sprite = result.sprites;
    }

    void Spin()
    {
        if (finalResults[0] == null || finalResults[1] == null || finalResults[2] == null)
        {
            return;
        }

        SlotSymbol s1 = finalResults[0];
        SlotSymbol s2 = finalResults[1];
        SlotSymbol s3 = finalResults[2];

        int totalValue = s1.value + s2.value + s3.value;

        RewardTier reward = GetRewardTier(totalValue);

        if (reward != null && reward.powerUp != null)
        {
            ApplyPowerUp(reward.powerUp);

            ShowPopup(reward.powerUp);
        }

        slotSymbol[0] = s1.sprites;
        slotSymbol[1] = s2.sprites;
        slotSymbol[2] = s3.sprites;
    }
    #endregion
    #region Status Affects
    RewardTier GetRewardTier(int totalValue)
    {
        foreach (RewardTier tiers in rewards)
        {
            if(totalValue >= tiers.minValue &&
            totalValue <= tiers.maxValue)
            {
                return tiers;
            }
        }

        return null;
    }

    void ApplyPowerUp(Powerup powerup)
    {
        switch (powerup.type)
        {
            case PowerUpType.Speed:
                //player.currentspeed += powerup.amount;
                break;

            case PowerUpType.Health:
                //playerHealth.currenthealth += (int)powerup.amount;
                break;
        }
    }

    void ShowPopup(Powerup powerup)
    {
        rewardIcon.SetActive(true);

        rewardIcon.GetComponent<Image>().sprite = powerup.powerupIcon.GetComponent<Image>().sprite;

        rewardText.text = powerup.powerUpName + "\n" + powerup.description;
    }
    #endregion
    #region Interaction
    [HideInInspector] bool playerIsNear;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }

    void OpenGamblingMachine()
    {
        if (playerIsNear && interactAction.IsPressed())
        {
            buttonBehavior.GamblingMachineMenuOn();
        }
    }
    #endregion
}