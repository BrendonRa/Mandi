using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100f;
    [SerializeField]
    private Dialogs dialog;
    private bool InDialog = false;
    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        // Mover para frente/trás
        if (!InDialog)
        {
            transform.Translate(Vector3.forward * zAxis * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * xAxis * moveSpeed * Time.deltaTime);
        }
        
        // Mudança de Animações
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
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "NpcDialog" && Input.GetKeyDown("e"))
        {
            dialog.Dialog(other.gameObject.name);
            InDialog = true;
        }
        if (other.gameObject.tag == "NpcDialog" && Input.GetKeyDown("q"))
        {
            dialog.Dialog(default);
            InDialog = false;
        }
    }
}