using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePlayer : MonoBehaviour
{
    [SerializeField] private Sprite[] playerDesign;

    private int currentPlayerDesign;
    private int currentSceneIndex;

    private bool changeSprite;

    SpriteRenderer playerSprite;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex > 2)
        {
            playerSprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if (currentSceneIndex > 2)
        {
            if (changeSprite == true)
            {
                playerSprite.sprite = playerDesign[currentPlayerDesign];
            }  
        }
    }

    public void UpdatePlayerDesign(int _change)
    {
        currentPlayerDesign += _change;

        if (_change != 0)
        {
            changeSprite = true;
        }
        else
        {
            changeSprite = false;
        }

        if (currentPlayerDesign < 0)
        {
            currentPlayerDesign = playerDesign.Length - 1;
        }
        else if (currentPlayerDesign > playerDesign.Length - 1)
        {
            currentPlayerDesign = 0;
        }
    }
}