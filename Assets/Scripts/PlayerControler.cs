using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Animator anim;
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        // moviment.Translate(Vector3.forward * Time.deltaTime * zAxis * moveSpeed);
        // rb.MovePosition(transform.position + transform.forward * (zAxis * moveSpeed * Time.deltaTime));
        // rb.MovePosition(transform.position + transform.right * (xAxis * moveSpeed * Time.deltaTime));
        // rb.MoveRotation(Quaternion.Euler(0f, transform.rotation.y + xAxis * moveSpeed * Time.deltaTime, 0f));

        // Mover para frente/trás
        transform.Translate(Vector3.forward * zAxis * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * xAxis * moveSpeed * Time.deltaTime);

        // Rotacionar para esquerda/direita
        // transform.Rotate(Vector3.up * xAxis * rotationSpeed * Time.deltaTime);

        anim.SetFloat("input_x", zAxis);
        anim.SetFloat("input_z", xAxis);

        if (zAxis != 0 || xAxis != 0)
        {
            if (!(Mathf.Round(zAxis) == 0)) anim.SetFloat("xDir", Mathf.Round(zAxis));
            if (!(Mathf.Round(xAxis) == 0)) anim.SetFloat("zDir", Mathf.Round(xAxis));
            anim.SetBool("isWalking", true);
        } else {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("attack");
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "NpcDialog")
        {
            Debug.Log("foi");
            PlayerPrefs.SetString("Dialogs", other.gameObject.name);
            PlayerPrefs.Save();
        }
        if (other.gameObject.tag == "NpcDialog" && Input.GetKey("q"))
        {
            Debug.Log("saiu");
            PlayerPrefs.DeleteKey("Dialogs");
        }
    }
}