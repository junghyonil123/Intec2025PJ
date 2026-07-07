using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct StageData
{
    public int level;
    public int enemyMaxHP;
    public int rewardGold;
}

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [SerializeField]
    List<StageData> Stages;

    [SerializeField]
    int curHP;

    public void InitializeStage()
    {
        StageData targetStage = Stages[0];
        curHP = targetStage.enemyMaxHP;
    }

    private void Awake()
    {
        instance = this;
    }

    public void SpawnSlime()
    {
        for (int i = 0; i < PlayerController.playerData.ownedSlimes.Count; i++)
        {
            Slime targetSlime = PlayerController.playerData.ownedSlimes[i];
            targetSlime.PreparBattle();
            spanwedSlime.Add(Instantiate(targetSlime, spawnPos.position + Vector3.right * i, Quaternion.identity).gameObject); 
        }

        UIManager.instance.PreparBattle();

        foreach (var item in spanwedSlime)
            item.GetComponent<Slime>().StopMove();

        AttackEnemy();
    }

    [SerializeField]
    Transform spawnPos;

    [SerializeField]
    List<GameObject> spanwedSlime;

    void AttackEnemy()
    {
        foreach (var slime in spanwedSlime)
        {
            StartCoroutine(MoveToTarget(slime));
        }
    }

    [SerializeField]
    Transform targetTransform;

    IEnumerator MoveToTarget(GameObject slime)
    {
        Vector3 moveVec = targetTransform.position - slime.transform.position;
        Vector3 slimeDefaultPos = slime.transform.position;

        for (int i = 0; i < 50; i++)
        {
            slime.transform.position = slimeDefaultPos + moveVec / (50 - i);
            yield return new WaitForFixedUpdate();
        }

        curHP -= slime.GetComponent<Slime>().attackDamage;
        Destroy(slime);
    }
}
