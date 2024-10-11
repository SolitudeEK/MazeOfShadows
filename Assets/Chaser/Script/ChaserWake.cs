using System.Collections;
using UnityEngine;

public class ChaserWake : MonoBehaviour
{
    [SerializeField]
    private GameObject _chaser;
    [SerializeField] 
    private AudioClip _awaknessSound;
    [SerializeField]
    private float _delay = 2;
    [SerializeField]
    private Animator _awakeAnimation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundFXManager.Instance.PlaySound(_awaknessSound, this.transform, 1);
            _awakeAnimation.SetTrigger("Awake");
            StartCoroutine(DelayedWake(_delay));
        }

        IEnumerator DelayedWake(float delay)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(_chaser, this.transform.position, new Quaternion(0,0,0,0)).SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
