using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    //앞뒤로 움직임 지속적으로?
    //일정위치가 되면 반대방향으로 전환

    Vector3 startPos;
    float goalPosZ;
    Vector3 dir = Vector3.forward;

    private void Start()
    {
        startPos = transform.position;
        goalPosZ = startPos.z + 10;
    }

    void Moving()
    {
        transform.position += dir * Time.deltaTime * 3;
        if (transform.position.z >= goalPosZ)
            dir = Vector3.back;
        if(transform.position.z <= startPos.z)
            dir = Vector3.forward;
    }


    private void Update()
    {
        Moving();
    }
}
