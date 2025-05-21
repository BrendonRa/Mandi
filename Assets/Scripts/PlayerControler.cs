using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rb;
    public Animator anim;
    public float moveSpeed = 5.0f;
    //private Camera _mainCamera;
    private SpriteRenderer sprite;
    public Transform moviment;
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");

        //moviment.Translate(Vector3.forward * Time.deltaTime * zAxis * moveSpeed);
        rb.MovePosition(transform.position + new Vector3(xAxis,0,zAxis) * moveSpeed * Time.deltaTime);
        // rb.MoveRotation(Quaternion.Euler(0f, transform.rotation.y + xAxis * moveSpeed * Time.deltaTime, 0f));

        if (zAxis != 0 || xAxis != 0)
        {
            anim.SetFloat("input_x", xAxis);
            anim.SetFloat("input_z", zAxis);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("attack");
        }
        /*
        Vector3 cameraPosition = _mainCamera.transform.position;
        cameraPosition.y = transform.position.y;
        transform.LookAt(cameraPosition);
        transform.Rotate(0f, 180f, 0f);
        */
    }
}