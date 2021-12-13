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

    public void TakeDamage()
    {
        _healthPlayer -= _damage;
    }

    private void SetMaxHealth()
    {
        _slider.maxValue = _healthPlayer;
        _slider.value = _healthPlayer;
    }
}
