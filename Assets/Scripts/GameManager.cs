using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    
    private float timeElapsed = 0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        TimeCounter();
    }

    void TimeCounter()
    {
        timeElapsed += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    } 
}
