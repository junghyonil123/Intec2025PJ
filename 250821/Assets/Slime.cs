using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public int hp = 100;
    public float speed;

    public Player target; 

    private void Update()
    {
        Vector3 targetPos = target.gameObject.transform.position;
        Vector3 myPos = transform.position;

        Vector3 dirVec = (targetPos - myPos).normalized;

        transform.position += dirVec * speed;
        //target ~~~
        //플레이어를 따라감

    }
}
