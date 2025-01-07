using System.Collections.Generic;
using UnityEngine;

public class GoldList : MonoBehaviour
{
    [SerializeField] private List<Gold> _list;

    private Transform _conteiner;

    public bool HaveResources => _list.Count > 0;

    private void Awake()
    {
        _conteiner = GetComponent<Transform>();
        _list = new List<Gold>();
    }

    public void AddGold(Gold gold)
    {
        _list.Add(gold);
        gold.transform.parent = _conteiner;
    }

    public void RemoveGold(Gold gold)
    {
        _list.Remove(gold);
        gold.transform.parent = null;
    }

    public Gold GetGoldMinimumDistance(Vector3 position)
    {
        Gold currentGold = _list[0];

        foreach (Gold gold2 in _list)
            if (CalculateDistance(position, gold2.transform.position) < CalculateDistance(position, currentGold.transform.position))
                currentGold = gold2;

        return currentGold;
    }

    private float CalculateDistance(Vector3 target, Vector3 position)
    {
        return (target - position).sqrMagnitude;
    }
}