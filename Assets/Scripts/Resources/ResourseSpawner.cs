using UnityEngine;

public class ResourseSpawner : MonoBehaviour
{
    [SerializeField] private Gold _prefab;
    [SerializeField] private BoxCollider _spawnZone;

    private void Start()
    {
        Spawn();
    }

    private void OnDestroing(Gold gold)
    {
        gold.Destroing -= OnDestroing;
        Destroy(gold.gameObject);
    }

    private void Spawn()
    {
        int minSpawnedResources = 50;
        int maxSpawnedResources = 100;
        int spawnerResources = Random.Range(minSpawnedResources, maxSpawnedResources + 1);

        for (int i = 0; i < spawnerResources; i++)
        {
            Gold gold = Instantiate(_prefab, GetRandomPosition(), Quaternion.identity);
            gold.Destroing += OnDestroing;
        }
    }

    private Vector3 GetRandomPosition()
    {
        float positionY = 0;
        float positionX = Random.Range(_spawnZone.bounds.min.x, _spawnZone.bounds.max.x);
        float positionZ = Random.Range(_spawnZone.bounds.min.z, _spawnZone.bounds.max.z);

        return new Vector3(positionX, positionY, positionZ);
    }
}
