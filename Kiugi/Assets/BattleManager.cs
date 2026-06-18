using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [SerializeField]
    Transform spawnPos;

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
            Instantiate(targetSlime, spawnPos.position + Vector3.right * i, Quaternion.identity);
        }

        UIManager.instance.PreparBattle();
    }
}
