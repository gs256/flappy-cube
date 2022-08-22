using System;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    public event Action StartClicked;
    public event Action RestartClicked;
    public event Action ExitClicked;
    public event Action Paused;
    public event Action Resumed;

    [SerializeField]
    private StartUi _startUi;

    [SerializeField]
    private GameOverUi _gameOverUi;

    private void Start()
    {
        _gameOverUi.Hide();
    }

    private void OnEnable()
    {
        _startUi.StartClicked += OnStartClicked;
        _gameOverUi.RetryClicked += OnRestartClicked;
    }

    private void OnDisable()
    {
        _startUi.StartClicked -= OnStartClicked;
        _gameOverUi.RetryClicked -= OnRestartClicked;
    }

    public void ShowStartUi()
    {
        _startUi.Show();
    }

    public void ShowGameOverUi()
    {
        _gameOverUi.Show();
    }

    private void OnStartClicked() => StartClicked?.Invoke();
    private void OnRestartClicked() => RestartClicked?.Invoke();
    private void OnExitClicked() => ExitClicked?.Invoke();
}
