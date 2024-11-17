using System.Collections.Generic;
using UnityEngine;

public class GoldList : MonoBehaviour
{
    [SerializeField] private List<Gold> _list;

    private Transform _conteiner;
    private List<Gold> _golds;

    private void Awake()
    {
        _conteiner = GetComponent<Transform>();
        _golds = new List<Gold>();

        foreach (Gold gold in _list)
            AddGold(gold);

        _list.Clear();
    }

    public void AddGold(Gold gold)
    {
        _golds.Add(gold);
        gold.transform.parent = _conteiner;
    }

    public void RemoveGold(Gold gold)
    {
        _golds.Remove(gold);
        gold.transform.parent = null;
    }

    public bool HaveResorce()
    {
        return _golds.Count > 0;
    }

    public Gold GetGoldMinimumDistance(Vector3 position)
    {
        Gold currentGold = _golds[0];

        foreach (Gold gold2 in _golds)
            if (CountDistance(position, gold2.transform.position) < CountDistance(position, currentGold.transform.position))
                currentGold = gold2;

        return currentGold;
    }

    private float CountDistance(Vector3 target, Vector3 position)
    {
        return (target - position).sqrMagnitude;
    }
}