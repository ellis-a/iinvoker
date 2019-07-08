using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public GameObject Projectile;
    public float Speed = 100f;
    private Camera _cam;

    // Use this for initialization
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = new Vector2();
            var aspect = _cam.pixelWidth / _cam.pixelHeight;
            mousePos.x =  (Input.mousePosition.x / _cam.pixelWidth - 0.5f) * aspect;
            mousePos.y = (Input.mousePosition.y / _cam.pixelHeight - 0.5f) / aspect;

            var direction = new Vector3(mousePos.x, 0, mousePos.y);
            direction.Normalize();

            var instProjectile = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
            var instProjectileRigidBody = instProjectile.GetComponent<Rigidbody>();

            instProjectileRigidBody.velocity = direction * Speed;
        }
    }
}
