using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume { get; private set; } = 1;
    public static float soundEffectsVolume { get; private set; } = 1;

    [SerializeField]
    private TextMeshProUGUI musicSliderText;
    [SerializeField]
    private TextMeshProUGUI soundEffectsSliderText;

    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider soundEffectsSlider;

    void Start()
    {
        musicSliderText.text = ((int)(musicVolume * 100)).ToString();
        soundEffectsSliderText.text = ((int)(soundEffectsVolume * 100)).ToString();

        musicSlider.value = musicVolume;
        soundEffectsSlider.value = soundEffectsVolume;
    }

    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;

        musicSliderText.text = ((int)(value * 100)).ToString();
        AudioManager.Instance.UpdateMixerVolume();
    }

    public void OnSoundEffectsSliderValueChange(float value)
    {
        soundEffectsVolume = value;

        soundEffectsSliderText.text = ((int)(value * 100)).ToString();
        AudioManager.Instance.UpdateMixerVolume();
    }
}
