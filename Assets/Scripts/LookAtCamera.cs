using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    // Update is called once per frame
    void Update()
    {
        if (_camera == null) { _camera = Camera.main; }
        if (_camera == null) { return; }

        transform.LookAt(_camera.transform);
    }
}
