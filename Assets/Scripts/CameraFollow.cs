using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float xOffset = 0f;
    public float zOffset = 0f;

    void Update()
    {
        transform.position = new Vector3(Player.position.x + xOffset, 
            transform.position.y, Player.position.z + zOffset);
    }
}
