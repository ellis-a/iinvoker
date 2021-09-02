using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField]
    public float HitPoints;

    public void TakeDamage(float damage)
    {
        HitPoints -= damage;
        if (HitPoints <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
