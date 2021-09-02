using UnityEngine;

[CreateAssetMenu(menuName = "Spells/ProjectileSpell")]
public class ProjectileSpell : Spell
{
    [SerializeField]
    public Rigidbody ProjectilePrefab;
    [SerializeField]
    public float ProjectileSpeed;
    [SerializeField]
    public float ProjectileRange;

    public override void Initialize(GameObject obj)
    {
        
    }

    public override void CastSpell()
    {
        Launch(ProjectileSpeed, ProjectileRange, Damage);
    }

    public void Launch(float speed, float range, float damage)
    {
        Launch(speed, range, damage, 0f);
    }

    public void Launch(float speed, float range, float damage, float angle)
    {
        var rotation = CastPoint.rotation * Quaternion.Euler(0, angle, 0);
        var projectile = Instantiate(ProjectilePrefab, CastPoint.position, rotation).GetComponent<Projectile>();
        projectile.SetValues(speed, range, damage);
    }
}