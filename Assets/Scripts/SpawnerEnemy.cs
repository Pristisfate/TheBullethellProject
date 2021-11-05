using UnityEngine;

public class SpawnerEnemy : ObjectPool
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _spawnPointEnemy;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _timeBetweenSpawn = 0;

    private void Start()
    {
        Initialize(_enemy);
    }
    private void Update()
    {
            _timeBetweenSpawn += Time.deltaTime;

            if (_timeBetweenSpawn >= _secondsBetweenSpawn)
            {
                if (TryGetObject(out GameObject enemy))
                {
                    _timeBetweenSpawn = 0;

                    int pointNumber = Random.Range(0, _spawnPointEnemy.Length);
                    SetEnemy(enemy, _spawnPointEnemy[pointNumber].position);
                }
            }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
