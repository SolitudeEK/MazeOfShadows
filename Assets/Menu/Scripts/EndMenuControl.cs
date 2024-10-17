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
    private TextMeshProUGUI _mazeDifLevelText;
    [SerializeField]
    private TextMeshProUGUI _playerScoreText;
    [SerializeField]
    private Button _quitButton;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private MazeGenerator _maze;
    [SerializeField]
    private int _baseScore=1000;

    private float _startTime;
    private float _difficultyRatio;

    private readonly string[] _mazeDifLevel = new string[] { "Impossible", "Hard", "Medium", "Easy" };

    public void SetResults(bool isWin)
    {
        this.gameObject.SetActive(true);
        _resultText.text = isWin ? "You Win!" : "You Lose";
    }

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

        _mazeDifLevelText.text = $"Maze Diffuculty: {MazeLevel()}";
        _playerScoreText.text = $"Score: {PlayerScore(time)}";
    }

    private void ToMainMenu()
        => SceneManager.LoadScene("Menu");

    private void Restart()
        => SceneManager.LoadScene("Maze");

    private string MazeLevel()
    {
        var mazeLength = PathFinder.FindPath(_maze.GetStart.ToVector2Int(), _maze.GetFinish.ToVector2Int()).Count;
        var possibleLength = (float)(MazeConfig.MazeHeight - 1) * (MazeConfig.MazeWidth - 1) / 11;
        _difficultyRatio = mazeLength / possibleLength;

        if (_difficultyRatio > 0.7)
            return _mazeDifLevel[0];
        else if (_difficultyRatio > 0.5)
            return _mazeDifLevel[1];
        else if (_difficultyRatio > 0.3)
            return _mazeDifLevel[2];
        else
            return _mazeDifLevel[3];
    }

    private int PlayerScore(TimeSpan time)
    {
        var mazeSizeBonus = (MazeConfig.MazeHeight - 1) * (MazeConfig.MazeWidth - 1);

        var timePenalty = 5 * time.TotalSeconds;

        int result = (int)(Math.Floor(mazeSizeBonus * _difficultyRatio ) - timePenalty + _baseScore);
        return Math.Max(0, result);
    }
}
public static class EndMenuControlExtenssion 
{
    public static Vector2Int ToVector2Int(this (int X, int Y) coord)
        => new Vector2Int(coord.X, coord.Y);
}

