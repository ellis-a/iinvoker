using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 _firingPoint;

    private float _speed;
    private float _range;
    private float _damage;

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

    void MoveProjectile()
    {
        if (Vector3.Distance(_firingPoint, transform.position) > _range)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
