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
            var instProjectile = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
            var instProjectileRigidBody = instProjectile.GetComponent<Rigidbody>();
            Event currentEvent = Event.current;
            var mousePos = new Vector2();

            mousePos.x = currentEvent.mousePosition.x;
            mousePos.y = _cam.pixelHeight - currentEvent.mousePosition.y;
            var point = _cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, _cam.nearClipPlane));

            var direction = point - transform.position;
            direction.Normalize();

            instProjectileRigidBody.AddForce(direction * Speed);
        }
    }
}
