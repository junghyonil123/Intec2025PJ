using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float colTime = 5f;

    public void Awake()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSecondsRealtime(colTime); //sleep
        }
    }

    [SerializeField]
    Transform leftBtm;
    [SerializeField]
    Transform rightTop;
    [SerializeField]
    GameObject slime1;

    void Spawn()
    {
        Instantiate(slime1, new Vector3(Random.Range(leftBtm.position.x, rightTop.position.x),
            Random.Range(leftBtm.position.y, rightTop.position.y), 0f), Quaternion.identity) ; 
    }



}
