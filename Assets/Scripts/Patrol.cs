using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;

    private int _currentpoint;
    void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

    }

    void Update()
    {

        Transform target = _points[_currentpoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        if (transform.position == target.position)
        {
            _currentpoint++;
            if (_currentpoint >= _points.Length)
            {
                _currentpoint = 0;
            }

        }
    }
}
