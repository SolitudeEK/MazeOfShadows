using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private Slider _masterSlider;
    [SerializeField]
    private Slider _soundFXSlider;
    [SerializeField]
    private Slider _musicSlider;

    public void SetMasterVolume(float level)
        => _audioMixer.SetFloat("masterVolume", level.Interpolate());

    public void SetSoundFXVolume(float level)
        => _audioMixer.SetFloat("soundFXVolume", level.Interpolate());

    public void SetMusicVolume(float level)
        => _audioMixer.SetFloat("musicVolume", level.Interpolate());

    private void Start()
        => UpdateSliders();

    private void UpdateSliders()
    {
        _audioMixer.GetFloat("masterVolume", out float masterVolume);
        _audioMixer.GetFloat("soundFXVolume", out float soundFXVolume);
        _audioMixer.GetFloat("musicVolume", out float musicVolume);

        _masterSlider.value = masterVolume.ReverseInterpolate();
        _soundFXSlider.value = soundFXVolume.ReverseInterpolate();
        _musicSlider.value = musicVolume.ReverseInterpolate();
    }
}
public static class SoundMixerManagerExtenssion 
{
    public static float Interpolate(this float value)
        => Mathf.Log10(value) * 20;

    public static float ReverseInterpolate(this float value)
    => Mathf.Pow(10, value / 20);
}

