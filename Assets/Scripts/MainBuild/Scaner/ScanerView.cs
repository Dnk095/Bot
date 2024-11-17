using UnityEngine;
using UnityEngine.UI;

public class ScanerView : MonoBehaviour
{
    [SerializeField] private Scaner _scaner;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider.value = 0;
    }

    private void OnEnable()
    {
        _scaner.ChangeTime += OnChangeTime;
    }

    private void OnDisable()
    {
        _scaner.ChangeTime -= OnChangeTime;
    }

    private void OnChangeTime(float time)
    {
        _slider.value = time;
    }
}
