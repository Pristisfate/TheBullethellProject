using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private int _healthEnemy;
    [SerializeField] private ScoreCounter _scoreCounter;


    private void Update()
    {
        if (_healthEnemy <= 0)
        {
            _scoreCounter.OnScoreChanged();
            gameObject.SetActive(false);
            _healthEnemy = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.TryGetComponent<BulletPlayer>(out BulletPlayer bullet))
            {
                _healthEnemy = _healthEnemy - 1;
            }
    }
}
