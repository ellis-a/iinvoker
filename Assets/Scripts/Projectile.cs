using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 _firingPoint;

    [SerializeField]
    public float ProjectileSpeed;
    [SerializeField]
    public float ProjectileRange;

    void Start()
    {
        _firingPoint = transform.position;
    }

    void Update()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        if (Vector3.Distance(_firingPoint, transform.position) > ProjectileRange)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * ProjectileSpeed * Time.deltaTime);
        }
    }
}
