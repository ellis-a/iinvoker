using UnityEngine;

[CreateAssetMenu(menuName = "Spells/MultiProjectileSpell")]
public class MultiProjectileSpell : ProjectileSpell
{
    [SerializeField]
    public int NumberOfProjectiles;
    [SerializeField]
    public float TimeBetweenProjectiles;
    [SerializeField]
    public float FireArc;

    public override void Initialize(GameObject obj)
    {
        //CastPoint = obj.GetComponent<ProjectileShootTriggerable>();
        //CastPoint.Projectile = ProjectilePrefab;
    }   //

    public override void CastSpell()
    {
        //var full_arc = 2 * FireArc;
        //var angle = -1 * FireArc;
        //var section = full_arc / (NumberOfProjectiles -1);
        //for (int i = 0; i < NumberOfProjectiles; i++)
        //{
        //    CastPoint.Launch(ProjectileSpeed, ProjectileRange, Damage, angle);
        //    angle += section;
        //}
    }
}