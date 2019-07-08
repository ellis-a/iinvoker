using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _moveSpeed;

    // Use this for initialization
    void Start()
    {
        _moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, _moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
