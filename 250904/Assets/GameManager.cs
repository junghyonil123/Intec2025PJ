using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    MonsterManager monsterManager;

    public void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        monsterManager.SpawnMonster(1);
        Player.Instance.Initialize();
    }
}
