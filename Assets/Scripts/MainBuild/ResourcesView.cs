using TMPro;
using UnityEngine;

public class ResourcesView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ResourceCounter _counter;

    private void OnEnable()
    {
        _counter.ChangedGold += OnChangedGold;
    }

    private void OnDisable()
    {
        _counter.ChangedGold -= OnChangedGold;
    }

    private void OnChangedGold(int quantity)
    {
        _text.text = quantity.ToString();
    }
}
