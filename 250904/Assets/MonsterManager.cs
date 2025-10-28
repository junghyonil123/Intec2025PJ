using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField]
    GameObject monster;
    [SerializeField]
    List<Transform> spawnPosList;
    [SerializeField]
    float spawmCool = 1f;
    [SerializeField]
    int spawnedMonsterCnt = 10;

    public void SpawnMonster(int stage)
    {
        StartCoroutine(SpawnMonsterAsync(stage));
    }

    IEnumerator SpawnMonsterAsync(int stage)
    {
        for (int i = 0; i < spawnedMonsterCnt; i++)
        {
            Instantiate(monster, spawnPosList[Random.Range(0, 2)].position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(spawmCool);
        }
    }
}
