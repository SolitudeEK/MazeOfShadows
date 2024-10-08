using UnityEngine;

public class CompassCollectable : MonoBehaviour
{
    [SerializeField]
    private ItemsControll _itemsControl;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _itemsControl.AddCompassCharge();
            this.gameObject.SetActive(false);
        }
    }
}
