using Items;
using System.Collections;
using UnityEngine;

public class ItemsControll : MonoBehaviour
{
    [SerializeField]
    private GameObject _compass;

    private ItemsInputAction _itemsAction;
    private const float _compassHideTimer= 5f;
    private int _compassCharges=0;

    public void AddCompassCharge()
        => _compassCharges++;

    private void Awake()
    {
        _itemsAction = new ItemsInputAction();

        _itemsAction.Items.Compass.performed += _ => ShowCompass();
    }

    private void OnEnable()
        => _itemsAction.Enable();

    private void OnDisable()
        => _itemsAction.Disable();

    private void ShowCompass()
    {
        if (_compassCharges > 0)
        {
            _compassCharges--;

            _compass.SetActive(true);

            StartCoroutine(HideCompassAfterDelay());
        }

        IEnumerator HideCompassAfterDelay()
        {
            yield return new WaitForSeconds(_compassHideTimer);
            _compass.SetActive(false);
        }
    }
}
