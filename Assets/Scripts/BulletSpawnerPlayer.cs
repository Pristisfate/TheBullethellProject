using UnityEngine;

public class BulletSpawnerPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _bulletResource;
    [SerializeField] private float _minRotation;
    [SerializeField] private float _maxRotation;
    [SerializeField] private int _numberOfBullets;
    [SerializeField] private bool _isRandom;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Vector2 _bulletVelocity;

    private float _timer;


    float[] rotations;
    private void Start()
    {
        _timer = _cooldown;
        rotations = new float[_numberOfBullets];
        if (!_isRandom)
        {
            DistributedRotations();
        }
    }
    private void Update()
    {
        if (_timer <= 0)
        {
            SpawnBullets();
            _timer = _cooldown;
        }
        _timer -= Time.deltaTime;
    }
    private float[] RandomRotations()
    {
        for (int i = 0; i < _numberOfBullets; i++)
        {
            rotations[i] = Random.Range(_minRotation, _maxRotation);
        }
        return rotations;

    }
    private float[] DistributedRotations()
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
    private GameObject[] SpawnBullets()
    {
        if (_isRandom)
        {
            RandomRotations();
        }

        GameObject[] spawnedBullets = new GameObject[_numberOfBullets];
        for (int i = 0; i < _numberOfBullets; i++)
        {
            spawnedBullets[i] = Instantiate(_bulletResource, transform);

            var b = spawnedBullets[i].GetComponent<BulletPlayer>();
            b.Rotation = rotations[i];
            b.Speed = _bulletSpeed;
            b.Velocity = _bulletVelocity;
        }
        return spawnedBullets;
    }
}
