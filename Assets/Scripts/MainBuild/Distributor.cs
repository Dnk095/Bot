using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distributor : MonoBehaviour
{
    [SerializeField] private GoldList _golds;

    private List<Worker> _workers;

    private bool _haveFlag = false;
    private Flag _flag;

    public event Action AddGold;
    public event Action<Worker> WorkerBuild;

    private void Awake()
    {
        _workers = new List<Worker>();
    }

    private void Start()
    {
        StartCoroutine(Work());
    }

    private void OnDisable()
    {
        foreach (Worker worker in _workers)
            worker.ReturnedToBase -= OnReturnedToBase;
    }

    public void Init(GoldList golds)
    {
        _golds = golds;
    }

    public void InitNewWorker(Worker worker)
    {
        worker.InitCreated(this);
        _workers.Add(worker);
        worker.ReturnedToBase += OnReturnedToBase;
    }

    public void GetFlag(Flag flag)
    {
        _flag = flag;
        _haveFlag = true;
    }

    private IEnumerator Work()
    {
        while (enabled)
        {
            if (_haveFlag == true && _workers.Count > 0)
                WorkerGoBuild();
            else if (_workers.Count > 0 && _golds.HaveResources && _haveFlag == false)
                WorkerGoMaining();

            yield return null;
        }
    }

    private void WorkerGoMaining()
    {
        Worker worker = _workers[0];
        Gold gold = _golds.GetGoldMinimumDistance(worker.transform.position);
        worker.Maining(gold);
        _golds.RemoveGold(gold);
        _workers.Remove(worker);
    }

    private void WorkerGoBuild()
    {
        Worker worker = _workers[0];
        _workers.Remove(worker);
        worker.StartBuild(_flag);
        _haveFlag = false;
        WorkerBuild?.Invoke(worker);
        worker.ReturnedToBase -= OnReturnedToBase;
    }

    private void OnReturnedToBase(Worker worker)
    {
        _workers.Add(worker);

        AddGold?.Invoke();
    }
}
