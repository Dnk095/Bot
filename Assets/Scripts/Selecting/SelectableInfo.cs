using System;
using UnityEngine;

public class SelectableInfo : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private ResourceCounter _counter;

    private int _quantityGolds;

    public string Name => _name;

    public int QuantityGolds => _quantityGolds;

    public event Action<int> ChangedGold;

    private void OnEnable()
    {
        _counter.ChangedGold += OnChangeGolds;
    }

    private void OnDisable()
    {
        _counter.ChangedGold -= OnChangeGolds;
    }

    private void OnChangeGolds(int quantityGolds)
    {
        ChangedGold?.Invoke(quantityGolds);
        _quantityGolds = quantityGolds;
    }
}
