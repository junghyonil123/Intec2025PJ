using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;

    public void Attack(Slime slime)
    {
        slime.hp -= 1;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.forward * speed;
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * speed;
        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.back * speed;
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Attack(collision.gameObject.GetComponent<Slime>());
        }
    }
}
