using System;
using UnityEngine;

public class Aquyma : MonoBehaviour
{
    public Transform target;
    public GameObject projectile;
    float cooldown = 0;
    GameManager direction;
    float speedProjectile = 5f;
    // Update is called once per frame
    void Update()
    {
        if (!(cooldown < 10)) Shoot();

        if (cooldown < 10)
        {
            cooldown += Time.deltaTime;
        }
        else cooldown = 0;
    }
    void Shoot()
    {
        GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        Transform trans = obj.GetComponent<Transform>();

        Vector3 directionGlobal = transform.TransformDirection(target.position);
        if (rb != null) rb.AddRelativeForce(directionGlobal * speedProjectile, ForceMode.Impulse);
    }
}
