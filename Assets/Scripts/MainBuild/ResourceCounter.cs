using System;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{
    private int _quantityGold;

    public event Action<int> ChangedGold;

    public void AddGold(int quantityGold = 1)
    {
        _quantityGold += quantityGold;
        ChangedGold?.Invoke(_quantityGold);
    }

    public void ReduseGold(int quantityGold)
    {
        _quantityGold -= quantityGold;
        ChangedGold?.Invoke(_quantityGold);
    }
}
