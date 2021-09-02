using UnityEngine;

public class ProjectileShootTriggerable : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody Projectile;    // Rigidbody variable to hold a reference to our projectile prefab
    public Transform FiringPoint;   // Transform variable to hold the location where we will spawn our projectile

    public void Launch(float speed, float range, int damage)
    {
        Launch(speed, range, damage, 0f);
    }

    public void Launch(float speed, float range, int damage, float angle)
    {
        var rotation = transform.rotation * Quaternion.Euler(0, angle, 0);
        var projectile = Instantiate(Projectile, FiringPoint.position, rotation).GetComponent<Projectile>();
        projectile.SetValues(speed, range, damage);
    }
}