using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUi : MonoBehaviour
{
    public event Action RetryClicked;
    public event Action ExitClicked;

    [SerializeField]
    private Button _retryButton;

    [SerializeField]
    private Button _exitButton;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _retryButton.onClick.AddListener(OnRetryClicked);
        _exitButton.onClick.AddListener(OnExitClicked);
    }

    private void OnDisable()
    {
        _retryButton.onClick.RemoveListener(OnRetryClicked);
        _exitButton.onClick.RemoveListener(OnExitClicked);
    }

    private void OnRetryClicked() => RetryClicked?.Invoke();
    private void OnExitClicked() => ExitClicked?.Invoke();
}
