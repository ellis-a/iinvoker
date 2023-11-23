using FishNet.Object;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : NetworkBehaviour
{
    private Vector3 _prevMouseLocation;

    [SerializeField]
    public Transform Target;
    [SerializeField]
    public float YOffset;
    [SerializeField]
    public float ZOffset;
    [SerializeField]
    public float FollowSpeed;
    [SerializeField]
    public float RotateSpeed;
    [SerializeField]
    public GameObject Rotator;

    public override void OnStartClient()
    {
        base.OnStartClient();
        EnableCamera();
    }

    [Client(RequireOwnership = true)]
    private void EnableCamera()
    {
        Camera cam = GetComponent<Camera>();
        cam.enabled = true;
    }

    void Update()
    {
        RotateCamera();
        //MoveCamera();
    }

    private void RotateCamera()
    {
        if (!Input.GetButton("CameraRotation"))
        {
            return;
        }

        if (Input.GetButtonDown("CameraRotation"))
        {
            _prevMouseLocation = Input.mousePosition;
        }

        //mouse moving left
        if (Input.mousePosition.x < _prevMouseLocation.x)
        {
            Rotator.transform.Rotate(0, (_prevMouseLocation.x - Input.mousePosition.x) * RotateSpeed * Time.deltaTime, 0);
        }
        //mouse moving right
        if (Input.mousePosition.x > _prevMouseLocation.x)
        {
            Rotator.transform.Rotate(0, (Input.mousePosition.x - _prevMouseLocation.x) * RotateSpeed * Time.deltaTime * -1, 0);
        }

        Mouse.current.WarpCursorPosition(_prevMouseLocation);
    }

    void MoveCamera()
    {
        var nextPosition = Target.transform.position + new Vector3(0, YOffset, ZOffset);
        
        transform.position = Vector3.Lerp(transform.position, nextPosition, FollowSpeed * Time.deltaTime);
    }
}
