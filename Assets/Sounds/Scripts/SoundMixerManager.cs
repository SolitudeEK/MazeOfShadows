using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _audioMixer;

    public void SetMasterVolume(float level)
        => _audioMixer.SetFloat("masterVolume", level.Interpolate());

    public void SetSoundFXVolume(float level)
        => _audioMixer.SetFloat("soundFXVolume", level.Interpolate());

    public void SetMusicVolume(float level)
        => _audioMixer.SetFloat("musicVolume", level.Interpolate());


}
public static class SoundMixerManagerExtenssion 
{
    public static float Interpolate(this float value)
        => Mathf.Log10(value) * 20;
}

