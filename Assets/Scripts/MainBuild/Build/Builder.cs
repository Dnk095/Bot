using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private MainBuild _prefab;
    [SerializeField] private List<MainBuild> _mainBuilds;
    [SerializeField] private MainBuild _readyBuild;
    [SerializeField] private GoldList _golds;

    private Worker _worker;

    private void Awake()
    {
        _mainBuilds = new List<MainBuild>();
    }

    private void Start()
    {
        AddNewBuild(_readyBuild);
    }

    private void AddNewBuild(MainBuild mainBuild)
    {
        mainBuild.WorkerGoBuild += OnGoBuild;
        _mainBuilds.Add(mainBuild);
    }

    private void OnGoBuild(Worker worker)
    {
        _worker = worker;
        worker.Building += OnBuilding;
    }

    private void OnBuilding(Vector3 position)
    {
        _worker.Building -= OnBuilding;
        MainBuild newBase = Instantiate(_prefab, position, Quaternion.identity);
        newBase.Init(_golds);
        newBase.AddBuilder(_worker);
        AddNewBuild(newBase);
        
    }
}
