using System;
using UnityEngine;
using UnityEngine.UI;

public class FlagButton : MonoBehaviour
{
    private Button _button;

    public event Action Used;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Push);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Push);
    }

    private void Push()
    {
        Used?.Invoke();
    }
}
