using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    float fallingCoolTime = 3f;
    Vector3 originPos; 

    void Falling() //함수 선언 이 클래스에 이런 기능이 있다.
    {
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void Start()
    {
        originPos = transform.position;
        Falling();
        remainTime = fallingCoolTime;
    }

    float remainTime;
    private void Update()
    {
        remainTime -= Time.deltaTime;
        if (remainTime <= 0)
        {
            //3초가 흐름
            transform.position = originPos;
            remainTime = fallingCoolTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindAnyObjectByType<GameManager>().Respawn();
        }
    }
}
