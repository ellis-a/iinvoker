using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWand : MonoBehaviour
{
    [SerializeField]
    public Transform FiringPoint;
    [SerializeField]
    public GameObject ProjectilePrefab;
    [SerializeField]
    public float CastCooldown;

    public static PlayerWand Instance;

    private float _lastFired = 0;

    void Awake()
    {
        Instance = GetComponent<PlayerWand>();
    }

    public void Shoot()
    {
        if (_lastFired + CastCooldown <= Time.time)
        {
            _lastFired = Time.time;
            Instantiate(ProjectilePrefab, FiringPoint.position, FiringPoint.rotation);
        }
    }
}
