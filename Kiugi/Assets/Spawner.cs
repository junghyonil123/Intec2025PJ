using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float colTime = 5f;

    int slimeCnt = 0;

    bool isSpawnable = true;
    IEnumerator CalculateSpawnable()
    {
        yield return new WaitForSecondsRealtime(colTime); //sleep
        isSpawnable = true;
    }

    [SerializeField]
    Transform leftBtm;
    [SerializeField]
    Transform rightTop;
    [SerializeField]
    GameObject slime1;

    public void TrySpawn()
    {
        if (slimeCnt >= PlayerController.playerData.GetMaxSpawnableSlime())
        {
            UIManager.instance.StartTextNotify("So many slime!!!!", 3f);
            return;
        }

        if (isSpawnable)
        {
            GameObject newSlime = Instantiate(slime1, new Vector3(Random.Range(leftBtm.position.x, rightTop.position.x),
                Random.Range(leftBtm.position.y, rightTop.position.y), 0f), Quaternion.identity);
            
            slimeCnt++;

            PlayerController.playerData.ownedSlimes.Add(newSlime.GetComponent<Slime>());

            UIManager.instance.SetSlimeCntText(slimeCnt);

            isSpawnable = false;

            StartCoroutine(CalculateSpawnable());
            //return true;
        }
        else
        {
            UIManager.instance.StartTextNotify("Spawn Fail", 3f);
            //return false;
        }
    }
}
