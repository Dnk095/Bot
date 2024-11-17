using System.Collections;
using UnityEngine;

public class WorkerSpawner : MonoBehaviour
{
    [SerializeField] private Worker _prefab;
    [SerializeField] private Transform _spawnPoint;

    private Coroutine _coroutine;

    public void Spawn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        float delay = 5f;
        float currentTime = 0;

        WaitForSeconds wait = new(Time.fixedDeltaTime);

        while (currentTime < delay)
            yield return wait;

        Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
    }
}
