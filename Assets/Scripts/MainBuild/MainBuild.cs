using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourceCounter), typeof(Distributor))]
public class MainBuild : MonoBehaviour
{
    [SerializeField] private List<Worker> _readyWorkers;

    private ResourceCounter _counter;
    private Distributor _distributor;

    private void Awake()
    {
        _distributor = GetComponent<Distributor>();
        _counter = GetComponent<ResourceCounter>();
    }

    private void OnEnable()
    {
        _distributor.AddGold += OnAddGold;
    }

    private void OnDisable()
    {
        _distributor.AddGold -= OnAddGold;
    }

    private void Start()
    {
        StartWorker();
    }

    private void StartWorker()
    {
        foreach (Worker worker in _readyWorkers)
            _distributor.InitNewWorker(worker);

        _readyWorkers.Clear();
    }

    private void OnAddGold()
    {
        _counter.AddGold();
    }
}
