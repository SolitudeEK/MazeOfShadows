using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public SoundFXManager Instance;

    [SerializeField]
    private AudioSource _soundObject;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PlaySound(AudioClip audioClip, Transform transform, float volume)
    {
        var audioSource = Instantiate(_soundObject, transform.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        Destroy(audioSource.gameObject, audioClip.length);
    }
}

