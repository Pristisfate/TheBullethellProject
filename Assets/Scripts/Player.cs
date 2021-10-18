using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _healthPlayerStart;
    private float _healthPlayer;

    [SerializeField] private float _invincibilityTime;
    private float _invincibilityTimer;

    private void Start()
    {
        _healthPlayer = _healthPlayerStart;
    }

    private void Update()
    {
        _invincibilityTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && _invincibilityTimer == 0)
        {
            _healthPlayer -= 10;
           _invincibilityTimer = _invincibilityTime;
        }
    }
}
