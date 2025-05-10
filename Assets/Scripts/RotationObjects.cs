using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObjects : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");

        if(xAxis == 1){
	        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,90,0) , moveSpeed);

        }

        if(xAxis == -1){
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,-90,0) , Time.deltaTime * moveSpeed);

        }
            
        if(zAxis == 1){
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,0,0), Time.deltaTime * moveSpeed);
        }

            
        if(zAxis == -1){
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,-180,0), Time.deltaTime * moveSpeed);
        }
    }
}
