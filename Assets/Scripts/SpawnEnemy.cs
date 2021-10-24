using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject[] Enemy;
    public Transform[] spawnPointEnemy;

    private int Position = 0;
    public bool infinityEnemy = false;
    public float startTimeBtwSpawns;
    private float timeBtwSpawn;

    void Start()
    {
        timeBtwSpawn = startTimeBtwSpawns;
    }

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            if (Position != spawnPointEnemy.Length)
            {
                Instantiate(Enemy[0], spawnPointEnemy[Position].transform.position,
                    Quaternion.identity);
                timeBtwSpawn = startTimeBtwSpawns;
                Position += 1;
            }
            else if (infinityEnemy == true)
            {
                Position = 0;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
