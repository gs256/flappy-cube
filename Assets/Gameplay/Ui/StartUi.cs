using System;
using UnityEngine;
using UnityEngine.UI;

public class StartUi : MonoBehaviour
{
    public event Action StartClicked;

    [SerializeField]
    private Button _startButton;

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
        _startButton.onClick.AddListener(OnStartClicked);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartClicked);
    }

    private void OnStartClicked()
    {
        StartClicked?.Invoke();
        Hide();
    }
}
