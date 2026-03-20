using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider playerVolumeSlider;
    public Slider musicSlider;

    private string playerVolumeParam = "JumpSoundVol";
    private string musicParam = "BackgroundMusicVol";

    void Start()
    {
        playerVolumeSlider.value = PlayerPrefs.GetFloat(playerVolumeParam, 1f);
        musicSlider.value = PlayerPrefs.GetFloat(musicParam, 1f);

        SetPlayerVolume(playerVolumeSlider.value);
        SetMusicVolume(musicSlider.value);
    }

    public void SetPlayerVolume(float value)
    {
        mixer.SetFloat(playerVolumeParam, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(playerVolumeParam, value);
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat(musicParam, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(musicParam, value);
    }
}
