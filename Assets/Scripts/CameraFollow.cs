using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    Vector3 velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Vector3.SmoothDamp(transform.position, followTarget.position, ref velocity, 0.1f);
        pos.z = transform.position.z;
        transform.position = pos;
    }
}
