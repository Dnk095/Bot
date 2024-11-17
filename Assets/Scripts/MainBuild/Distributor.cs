using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distributor : MonoBehaviour
{
    [SerializeField] private GoldList _golds;

    private List<Worker> _workers;

    public event Action AddGold;

    private void Awake()
    {
        _workers = new List<Worker>();
    }

    private void Start()
    {
        StartCoroutine(Maining());
    }

    private void OnDisable()
    {
        foreach (Worker worker in _workers)
            worker.ReturnedToBase -= OnReturnedToBase;
    }

    public void AddGoldToList(List<Gold> golds)
    {
        foreach (Gold gold in golds)
            _golds.AddGold(gold);
    }

    public void InitNewWorker(Worker worker)
    {
        _workers.Add(worker);
        worker.InitCreated(this);
        worker.ReturnedToBase += OnReturnedToBase;
    }

    private void WorkerGoMaining()
    {
        Worker worker = _workers[0];
        Gold gold = _golds.GetGoldMinimumDistance(worker.transform.position);
        _golds.RemoveGold(gold);
        worker.Init(gold);
        _workers.Remove(worker);
    }

    private IEnumerator Maining()
    {
        while (enabled)
        {
            if (_workers.Count > 0 && _golds.HaveResorce())
                WorkerGoMaining();

            yield return null;
        }
    }

    private void OnReturnedToBase(Worker worker)
    {
        _workers.Add(worker);

        AddGold?.Invoke();
    }
}
