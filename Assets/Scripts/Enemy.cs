using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthEnemy;
    void Start()
    {

    }
    void Update()
    {
        if (healthEnemy != 1)
        {
            Destroy(gameObject, 0.00001f);
            ScoreCount.Scorecount += 1;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
  
            if (collision.gameObject.tag == "BulletPlayer")
            {
 
                healthEnemy = healthEnemy - 1;
            }
    }
}
