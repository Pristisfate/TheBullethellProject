using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static List<GameObject> Bullets;
    void Start()
    {
        Bullets = new List<GameObject>();
    }

    public static GameObject GetBulletFromPool()
    {
        for (int i = 0; i < Bullets.Count; i++)
        {
            if (!Bullets[i].active)
            {
                Bullets[i].GetComponent<Bullet>().ResetTimer();
                Bullets[i].SetActive(true);
                return Bullets[i];
            }   
        }
        return null;
    }
}