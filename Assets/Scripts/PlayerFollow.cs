using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerControl : MonoBehaviour
{
    public Transform objectToFollow;
    public float followSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    

    void Update()
    {
        // calculate the distance between this object and the target object
        // and move a small portion of that distance each frame:

        var delta = objectToFollow.position - transform.position;
        transform.position += delta * Time.deltaTime * followSpeed;
    }
}
