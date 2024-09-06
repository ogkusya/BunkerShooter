using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyStateMachine prefab;
    [SerializeField] private EnemySpawnConfiguration[] spawnConfigurations;
    [SerializeField] private float interval = 10;

    private IPool<EnemyStateMachine> _enemyPool;

    private void Awake()
    {
        FactoryMonoObject<EnemyStateMachine> factory = new FactoryMonoObject<EnemyStateMachine>(prefab.gameObject, transform);
        _enemyPool = new Pool<EnemyStateMachine>(factory, 5);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            EnemySpawnConfiguration spawnConfig = spawnConfigurations[Random.Range(0, spawnConfigurations.Length - 1)];
            Vector3 randomPosition = spawnConfig.SpawnPosition.transform.position;
            _enemyPool.Pull().transform.position = randomPosition;
        }
    }
}
