using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float MovementSpeed;

    public List<MagicElement> ElementLoadout;
    public List<MagicElement> InvokedElements;
    private bool isInvoke1Input = false;
    private bool isInvoke2Input = false;
    private bool isInvoke3Input = false;

    public int MaxInvokedElements = 2;

    private Plane GroundPlane = new Plane(Vector3.up, 0);
    void Start()
    {

    }

    void Update()
    {
        HandleMovementSpeed();
        HandleRotationInput();
        HandleShootInput();
        HandleInvokeInputs();
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

    void HandleInvokeInputs()
    {
        HandleSingleInvokeInput("Invoke1", 0, ref isInvoke1Input);
        HandleSingleInvokeInput("Invoke2", 1, ref isInvoke2Input);
        HandleSingleInvokeInput("Invoke3", 2, ref isInvoke3Input);
    }

    void HandleSingleInvokeInput(string buttonName, int loadoutIndex, ref bool isInputPressed)
    {
        if (Input.GetButton(buttonName))
        {
            if (!isInputPressed)
            {
                isInputPressed = true;
                if (ElementLoadout.Count > loadoutIndex)
                {
                    InvokedElements.Insert(0, ElementLoadout[loadoutIndex]);

                    if (InvokedElements.Count > MaxInvokedElements)
                    {
                        InvokedElements.RemoveAt(InvokedElements.Count - 1);
                    }
                }
            }
        }
        else
        {
            isInputPressed = false;
        }
    }
}
