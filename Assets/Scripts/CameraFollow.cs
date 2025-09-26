using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target;
    public float smoothSpeed = 5f; // quanto maior, mais rápido acompanha
    public Vector3 locationOffset;
    public Vector3 rotationOffset;

    void Update() // usar LateUpdate para seguir de forma suave
    {
        if (target == null) return;

        // Posição desejada
        Vector3 desiredPosition = target.position + target.rotation * locationOffset;
        // Movimento suave usando deltaTime
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
