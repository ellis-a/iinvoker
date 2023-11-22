using FishNet.Object;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    [SerializeField]
    public Transform Target;
    [SerializeField]
    public Vector3 TargetOffset;
    [SerializeField]
    public float Speed;

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
        MoveCamera();
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + TargetOffset, Speed * Time.deltaTime);
    }
}
