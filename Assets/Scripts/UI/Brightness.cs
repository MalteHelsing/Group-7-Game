using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] Slider slider;

    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        if (volume.profile.TryGet(out colorAdjustments))
        {
            float savedBrightness = PlayerPrefs.GetFloat("Brightness", 0);
            
            slider.value = savedBrightness;
            SetBrightness(savedBrightness);

            slider.onValueChanged.AddListener(SetBrightness);
        }
    }

    public void SetBrightness(float value)
    {
        slider.value = colorAdjustments.postExposure.value;

        colorAdjustments.postExposure.value = value;
    }
}