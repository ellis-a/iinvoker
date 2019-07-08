using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float xOffset = 0f;
    public float zOffset = 0f;

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + xOffset, 
            transform.position.y, player.position.z + zOffset);
    }
}
