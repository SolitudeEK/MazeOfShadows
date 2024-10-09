using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;

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

    public GameObject PlaySoundLoop(AudioClip audioClip, Transform transform, float volume)
    {
        var audioSource = Instantiate(_soundObject, transform.position, Quaternion.identity);

        audioSource.loop = true;
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        return audioSource.gameObject;
    }
}

