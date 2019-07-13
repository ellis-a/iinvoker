using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float MovementSpeed;
    private Plane GroundPlane = new Plane(Vector3.up, 0);
    void Start()
    {

    }

    void Update()
    {
        HandleMovementSpeed();
        HandleRotationInput();
        HandleShootInput();
    }

    void HandleMovementSpeed()
    {
        transform.Translate(MovementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 
            MovementSpeed * Input.GetAxis("Vertical") * Time.deltaTime, Space.World);
    }

    void HandleRotationInput()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (GroundPlane.Raycast(ray, out distance))
        {
            var hit = ray.GetPoint(distance);
            transform.LookAt(new Vector3(hit.x, transform.position.y, hit.z));
        }
    }

    void HandleShootInput()
    {
        if (Input.GetButton("Fire1"))
        {
            PlayerWand.Instance.Shoot();
        }
    }
}
