using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObjects : MonoBehaviour
{
    public Transform rotationObject;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var rota = rotationObject.rotation.y;
        transform.rotation = Quaternion.Euler(0f, rotationObject.rotation.y, 0f);
    }
}
