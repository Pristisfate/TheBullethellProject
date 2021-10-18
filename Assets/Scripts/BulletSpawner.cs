using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bulletResource;
    [SerializeField] private float _minRotation;
    [SerializeField] private float _maxRotation;
    [SerializeField] private int _numberOfBullets;
    [SerializeField] private bool _isRandom;

    [SerializeField] private float _cooldown;
    private float _timer;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Vector2 _bulletVelocity;


    float[] rotations;
    void Start()
    {
        _timer = _cooldown;
        rotations = new float[_numberOfBullets];
        if (!_isRandom)
        {
            DistributedRotations();
        }
    }
    void Update()
    {
        if (_timer <= 0)
        {
            SpawnBullets();
            _timer = _cooldown;
        }
        _timer -= Time.deltaTime;
    }
    public float[] RandomRotations()
    {
        for (int i = 0; i < _numberOfBullets; i++)
        {
            rotations[i] = Random.Range(_minRotation, _maxRotation);
        }
        return rotations;

    }
    public float[] DistributedRotations()
    {
        for (int i = 0; i < _numberOfBullets; i++)
        {
            var fraction = (float)i / ((float)_numberOfBullets - 1);
            var difference = _maxRotation - _minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + _minRotation;
        }
        foreach (var r in rotations) print(r);
        return rotations;
    }
    public GameObject[] SpawnBullets()
    {
        if (_isRandom)
        {
            RandomRotations();
        }

        GameObject[] spawnedBullets = new GameObject[_numberOfBullets];
        for (int i = 0; i < _numberOfBullets; i++)
        {
            spawnedBullets[i] = Instantiate(_bulletResource, transform);

            var b = spawnedBullets[i].GetComponent<Bullet>();
            b.rotation = rotations[i];
            b.speed = _bulletSpeed;
            b.velocity = _bulletVelocity;
        }
        return spawnedBullets;
    }
}
