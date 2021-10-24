using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _healthPlayerStart;
    private float _healthPlayer;
    public Image bar;
    public float fill;

    [SerializeField] private float _invincibilityTime;
    private float _invincibilityTimer;
    private float _damage;

    private void Start()
    {
        fill = 1f;
        _healthPlayer = _healthPlayerStart;
        _damage = 10; 
    }

    private void Update()
    {
        bar.fillAmount = fill;
        _invincibilityTimer -= Time.deltaTime;
        if (_healthPlayer == 0)
        {
            Destroy(gameObject, .5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "BulletEnemy")
        {
            _healthPlayer -= _damage;
            fill = _healthPlayer * 0.01f;
        }
    }
}
