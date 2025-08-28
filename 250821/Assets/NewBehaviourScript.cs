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
        float curSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift))
            curSpeed *= 3f;

        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.forward * curSpeed;
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * curSpeed;
        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.back * curSpeed;
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * curSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Attack(collision.gameObject.GetComponent<Slime>());
        }
    }
}
