using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _settingsButton;
    [SerializeField]
    private Button _exitButton;
    [SerializeField] 
    private Button _backGameButton;
    [SerializeField]
    private Button _startSmallGame;
    [SerializeField] 
    private Button _startMediumGame;
    [SerializeField] 
    private Button _startBigGame;
    [SerializeField]
    private GameObject _stratGameMenu;
    [SerializeField]
    private GameObject _mainMenu;

    private readonly (int, int) SmallGameSize = (31, 31);
    private readonly (int, int) MediumGameSize = (51, 51);
    private readonly (int, int) BigGameSize = (71, 71);

    private void Awake()
    {
        _exitButton.onClick.AddListener(Exit);
        _startButton.onClick.AddListener(ShowGameMenu);
        _backGameButton.onClick.AddListener(BackGameMenu);

        _startSmallGame.onClick.AddListener(SetSmallGame);
        _startSmallGame.onClick.AddListener(StartGame);
        _startMediumGame.onClick.AddListener(SetMediumGame);
        _startMediumGame.onClick.AddListener(StartGame);
        _startBigGame.onClick.AddListener(SetBigGame);
        _startBigGame.onClick.AddListener(StartGame);
    }

    private void Exit()
    {
        Application.Quit();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }

    private void ShowGameMenu()
    {
        _mainMenu.SetActive(false);
        _stratGameMenu.SetActive(true);
    }

    private void BackGameMenu()
    {
        _stratGameMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    private void StartGame()
        => SceneManager.LoadScene("Maze");

    private void SetSmallGame()
        => MazeConfig.SetSize(SmallGameSize);

    private void SetMediumGame()
        => MazeConfig.SetSize(MediumGameSize);

    private void SetBigGame()
        => MazeConfig.SetSize(BigGameSize);

}
