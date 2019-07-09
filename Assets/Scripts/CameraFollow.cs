using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform Target;
    [SerializeField]
    public Vector3 TargetOffset;
    [SerializeField]
    public float Speed;

    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + TargetOffset, Speed * Time.deltaTime);
    }
}
