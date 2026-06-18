using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Camera homeCam;
    [SerializeField]
    Camera battleCam;

    public void GotoBattle()
    {
        homeCam.gameObject.SetActive(false);
        battleCam.gameObject.SetActive(true);

        BattleManager.instance.SpawnSlime();
    }

    public void ReturntoHome()
    {
        homeCam.gameObject.SetActive(true);
        battleCam.gameObject.SetActive(false);
    }
}
