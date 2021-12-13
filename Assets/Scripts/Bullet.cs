using UnityEngine;

public class Bullet: MonoBehaviour
{
    private float _timer;

    public Vector2 Velocity;
    public float Speed;
    public float Rotation;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Rotation);
    }
    private void Update()
    {
        transform.Translate(Velocity * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player bulletWithPlayer))
        {
            bulletWithPlayer.TakeDamage();
        }
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy bulletWithEnemy))
        {
            bulletWithEnemy.TakeDamage();
        }
        if (other.gameObject.TryGetComponent<Bullet>(out Bullet bulletWithBullet))
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.TryGetComponent<EmptyZone>(out EmptyZone bulletOutOfRange))
        {
            gameObject.SetActive(false);
        }
    }
}
