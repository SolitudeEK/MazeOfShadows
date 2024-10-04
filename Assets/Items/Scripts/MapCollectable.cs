using UnityEngine;

public class MapCollectable : MonoBehaviour
{
    [SerializeField]
    private GameObject _map;

    private void Awake()
        => _map.SetActive(false);
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _map.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
