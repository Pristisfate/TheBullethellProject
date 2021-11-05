using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _healthPlayerStart;
    [SerializeField] private Slider _slider;

    private float _healthPlayer;
    private float _damage;

    private void Start()
    {
        _healthPlayer = _healthPlayerStart;
        SetMaxHealth();
        _damage = 10; 
    }

    private void Update()
    {
        if (_healthPlayer == 0)
        {
            Destroy(gameObject, 0.00001f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<BulletEnemy>(out BulletEnemy bullet))
        {
            _healthPlayer -= _damage;
            _slider.value = _healthPlayer;
        }
    }

    private void SetMaxHealth()
    {
        _slider.maxValue = _healthPlayer;
        _slider.value = _healthPlayer;
    }
}
