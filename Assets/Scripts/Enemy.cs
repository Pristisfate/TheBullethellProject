using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _healthEnemy;
    
    public void TakeDamage()
    {
        gameObject.SetActive(false);
    }


}
