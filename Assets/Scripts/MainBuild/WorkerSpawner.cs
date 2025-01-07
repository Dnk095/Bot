using UnityEngine;

public class WorkerSpawner : MonoBehaviour
{
    [SerializeField] private Worker _prefab;
    [SerializeField] private Transform _spawnPoint;

    public Worker Spawn()
    {
       return Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
    }
}
