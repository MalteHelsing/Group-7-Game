using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSController : MonoBehaviour
{
    [SerializeField] Slider playerVolumeSlider;
    [SerializeField] Slider musicSlider;

    public void ChangeVolume()
    {
        PlayerPrefs.SetFloat("JumpVolume", playerVolumeSlider.value);
        PlayerPrefs.SetFloat("BackgroundVolume", musicSlider.value);
        PlayerPrefs.Save();
    }

    public void Update()
    {
        
    }
}
