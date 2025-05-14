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
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");

        //transform.Translate(Vector3.forward * Time.deltaTime * zAxis * moveSpeed);
        
        rb.MovePosition(transform.position + new Vector3(xAxis,0,zAxis) * moveSpeed * Time.deltaTime);

        if(zAxis != 0){
                anim.SetBool("isWalking", true);
        }else{
                anim.SetBool("isWalking", false);
        }

        if (Input.GetButtonDown("Fire1")){
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