using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveSpeed;

    // Use this for initialization
    void Start()
    {
        MoveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
