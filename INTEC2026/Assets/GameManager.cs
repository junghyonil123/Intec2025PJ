using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 플레이어가 죽엇을때 리스폰

    //f p
    
    [SerializeField]
    Vector3 spawnPos;
    [SerializeField]
    GameObject player;

    public void Respawn()
    {
        Debug.Log("리스폰함");
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = spawnPos;
        player.GetComponent<CharacterController>().enabled = true;
    }

    void CheckIsPlayerFalling()
    {
        if (player.transform.position.y < -5f)
        {
            Respawn();
        }
    }

    public void Clear()
    {
        Debug.Log("와 클리어!");
        Respawn();
    }

    public void Update()
    {
        CheckIsPlayerFalling();
    }
}
