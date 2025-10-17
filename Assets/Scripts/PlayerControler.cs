using UnityEngine;
using UnityEngine.Video;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private Dialogs dialog;
    private bool inDialog = false;
    
    [SerializeField]
    private Animator anim;
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100f;
    bool isWalking;
    float xAxis = 0;
    float zAxis = 0;
    public GameObject attackObj;
    public Transform att;
    private SpriteRenderer sprite;

    public int healthMax = 200;
    public int health = 200;
    public int damage = 5;
    void Start()
    {
        isWalking = false;
    }
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        isWalking = (xAxis != 0 || zAxis != 0);

        if (isWalking)
        {
            // Mover para frente/trás
            if (!inDialog)
            {
                transform.Translate(Vector3.forward * zAxis * moveSpeed * Time.deltaTime);
                transform.Translate(Vector3.right * xAxis * moveSpeed * Time.deltaTime);
            }

            // Mudança de Animações
            anim.SetFloat("input_z", xAxis);
            anim.SetFloat("input_x", zAxis);
        }

        anim.SetBool("isWalking", isWalking);

        if (Input.GetButtonDown("Fire1") && !inDialog)
        {
            anim.SetTrigger("attack");

            att.position = transform.position;

            if (anim.GetFloat("input_z") > 0) att.position += new Vector3(0, 0, 0.7f);
            if (anim.GetFloat("input_z") < 0) att.position += new Vector3(0, 0, -0.7f);
            if (anim.GetFloat("input_x") < 0) att.position += new Vector3(0.55f, 0, 0);
            if (anim.GetFloat("input_x") > 0) att.position += new Vector3(-0.55f, 0, 0);

            GameObject ataque = Instantiate(attackObj, att.position, Quaternion.identity);
            Destroy(ataque, 0.5f);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "NpcDialog")
        {
            if (Input.GetKeyDown("e"))
            {
                dialog.Dialog(other.gameObject.name);
                inDialog = true;
            }
            
            if (Input.GetButtonDown("Fire1") && inDialog) inDialog = dialog.NextDialog();
        }
    }
}