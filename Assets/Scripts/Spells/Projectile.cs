using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 _firingPoint;

    private float _speed;
    private float _range;
    private float _damage;

    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private bool explodeOnExpire;


    public void SetValues(float speed, float range, float damage)
    {
        _speed = speed;
        _range = range;
        _damage = damage;
    }

    void Start()
    {
        _firingPoint = transform.position;
    }

    void Update()
    {
        MoveProjectile();
    }

    void CreateExplosion(Vector3 forward)
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, this.transform.position, Quaternion.LookRotation(forward));
        }
    }

    void MoveProjectile()
    {
        if (Vector3.Distance(_firingPoint, transform.position) > _range)
        {
            if(explodeOnExpire)
            {
                CreateExplosion(transform.forward);
            }
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageTarget = other.GetComponent<IDamageable>();
        if (damageTarget != null)
        {
            damageTarget.TakeDamage(_damage);
            CreateExplosion(transform.position - other.ClosestPoint(transform.position));
        }

        Destroy(gameObject);
    }
}
