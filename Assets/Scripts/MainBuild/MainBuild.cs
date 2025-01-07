using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourceCounter), typeof(Distributor), typeof(WorkerSpawner))]
public class MainBuild : MonoBehaviour
{
    [SerializeField] private List<Worker> _readyWorkers;
    [SerializeField] private Flag _flag;

    private ResourceCounter _counter;
    private Distributor _distributor;
    private WorkerSpawner _spawner;

    private int _quantityWorkers;
    private int _workerPrice = 3;
    private int _basePrice = 5;

    private bool _flagTeked = false;

    public event Action<Worker> WorkerGoBuild;

    private void Awake()
    {
        _distributor = GetComponent<Distributor>();
        _counter = GetComponent<ResourceCounter>();
        _spawner = GetComponent<WorkerSpawner>();
    }

    public void Init(GoldList golds)
    {
        _distributor.Init(golds);
    }

    private void OnEnable()
    {
        _distributor.AddGold += OnAddGold;
        _distributor.WorkerBuild += OnWorkerGoBuild;
        _counter.ChangedGold += OnChangeGold;
    }

    private void OnDisable()
    {
        _distributor.AddGold -= OnAddGold;
        _distributor.WorkerBuild -= OnWorkerGoBuild;
        _counter.ChangedGold -= OnChangeGold;
    }

    private void Start()
    {
        if (_readyWorkers.Count > 0)
            AddReadyWorker();

        _flag.gameObject.SetActive(false);
    }

    public void AddBuilder(Worker worker)
    {
        _distributor.InitNewWorker(worker);
        _quantityWorkers++;
    }

    public void GetFlagPosition(Vector3 position)
    {
        _flag.transform.position = position;
        _flagTeked = true;
        _flag.gameObject.SetActive(true);
    }

    private void OnWorkerGoBuild(Worker worker)
    {
        WorkerGoBuild?.Invoke(worker);
        _quantityWorkers--;
    }

    private void OnChangeGold(int quantity)
    {
        int minQuantittyWorkerForBuild = 2;

        if (quantity >= _workerPrice && _flagTeked == false || _quantityWorkers < minQuantittyWorkerForBuild && quantity >= _workerPrice)
            Spawn();
        else if (quantity >= _basePrice && _flagTeked == true)
            Build();
    }

    private void Spawn()
    {
        Worker newWorker = _spawner.Spawn();
        _counter.ReduseGold(_workerPrice);
        AddBuilder(newWorker);
    }

    private void Build()
    {
        _flagTeked = false;
        _distributor.GetFlag(_flag);
        _counter.ReduseGold(_basePrice);
    }

    private void OnAddGold()
    {
        _counter.AddGold();
    }

    private void AddReadyWorker()
    {
        foreach (Worker worker in _readyWorkers)
            AddBuilder(worker);

        _readyWorkers.Clear();
    }
}
