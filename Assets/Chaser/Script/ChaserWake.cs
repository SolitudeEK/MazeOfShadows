using System.Collections;
using UnityEngine;

public class ChaserWake : MonoBehaviour
{
    [SerializeField]
    private GameObject _chaser;
    [SerializeField]
    private float _delay = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
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
