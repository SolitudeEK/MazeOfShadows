using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenuControl : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerText;
    [SerializeField]
    private TextMeshProUGUI _resultText;
    [SerializeField]
    private Button _quitButton;
    [SerializeField]
    private Button _restartButton;

    private float _startTime;

    private void Awake()
    {
        _startTime = Time.time;

        _quitButton.onClick.AddListener(ToMainMenu);
        _restartButton.onClick.AddListener(Restart);
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        var time = TimeSpan.FromSeconds(Time.time - _startTime);
        _timerText.text = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
    }

    private void ToMainMenu()
        => SceneManager.LoadScene("Menu");

    private void Restart()
        => SceneManager.LoadScene("Maze");

    public void SetResults(bool isWin)
    {
        this.gameObject.SetActive(true);
        _resultText.text = isWin ? "You Win!" : "You Lose";
    }
}
