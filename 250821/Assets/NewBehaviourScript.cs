using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public float speedOK = 0;

    public void Attack(Slime slime)
    {
        slime.hp -= 1;
        if(slime.hp <= 95)
        {
            speedOK = 1;
        }
    }

    private void Update()
    {
        float Curspeed = speed;
        if (speedOK == 1)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Curspeed = speed * 2;
            }
                
        }
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.forward * Curspeed;
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * Curspeed;
        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.back * Curspeed;
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * Curspeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Attack(collision.gameObject.GetComponent<Slime>());
        }
    }
}
