using UnityEngine;
using UnityEngine.UI;

public class SettingsInGame : MonoBehaviour
{
    [SerializeField]
    private Button _backButton;
    [SerializeField]
    private GameObject _settignsPage;

    private InGameInputAction _inGameIA;

    private void Awake()
    {
        _inGameIA = new InGameInputAction();

        _inGameIA.MenuInteraction.MenuCall.performed += _ => _settignsPage.SetActive(!_settignsPage.activeSelf);
        _backButton.onClick.AddListener(ClosePage);

        _settignsPage.SetActive(false);
    }
    private void OnEnable()
    => _inGameIA.Enable();

    private void OnDisable()
        => _inGameIA.Disable();

    private void ClosePage()
        => _settignsPage.SetActive(false);
}
