using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider playerVolumeSlider;
    [SerializeField] private Slider backgroundVolumeSlider;
    [SerializeField] private Slider menuVolumeSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BackgroundVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetJumpVolume();
            SetBackgroundVolume();
            SetMenuVolume();
        }
    }

    public void SetJumpVolume()
    {
        float volume = playerVolumeSlider.value;
        audioMixer.SetFloat("Jump", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("JumpVolume", volume);
    }

    public void SetBackgroundVolume()
    {
        float volume = backgroundVolumeSlider.value;
        audioMixer.SetFloat("Background", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("BackgroundVolume", volume);
    }

    public void SetMenuVolume()
    {
        float volume = backgroundVolumeSlider.value;
        audioMixer.SetFloat("Menu", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MenuVolume", volume);
    }

    private void LoadVolume()
    {
        playerVolumeSlider.value = PlayerPrefs.GetFloat("JumpVolume");
        backgroundVolumeSlider.value = PlayerPrefs.GetFloat("BackgroundVolume");

        SetJumpVolume();
        SetBackgroundVolume();
        SetMenuVolume();
    }
}