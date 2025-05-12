using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObjects : MonoBehaviour
{
    public float rotationSpeed = 150.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        CamOrbit();
    }
    private void CamOrbit() {
        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0) {
            float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, horizontalInput, Space.World);
        }
    }
}
