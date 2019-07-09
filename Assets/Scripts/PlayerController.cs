using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float MovementSpeed;

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

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
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
