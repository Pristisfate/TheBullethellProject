
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;
    public float rotation;
    public float LifeTime;
    float timer;
    
    void Start()
    {
        timer = LifeTime;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0) gameObject.SetActive(false);
    }
    public void ResetTimer()
    {
        timer = LifeTime;
    }
}