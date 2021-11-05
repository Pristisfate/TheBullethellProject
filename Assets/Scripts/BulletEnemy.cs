using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private float _timer;

    public Vector2 Velocity;
    public float Speed;
    public float Rotation;
    public float LifeTime;
    
    private void Start()
    {
        _timer = LifeTime;
        transform.rotation = Quaternion.Euler(0, 0, Rotation);
    }
    private void Update()
    {
        transform.Translate(Velocity * Speed * Time.deltaTime);
        _timer -= Time.deltaTime;
        if (_timer <= 0) gameObject.SetActive(false);
    }
    public void ResetTimer()
    {
        _timer = LifeTime;
    }
}