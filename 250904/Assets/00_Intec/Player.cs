using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int maxHP = 10;
    public int curHP = 10;

    public int maxEXP = 10;
    public int curEXP = 0;
    public int level = 1;

    public int attack = 3;
    public PlayerWeaponSystem playerWeaponSystem;

    private void Awake()
    {
        Instance = this;
    }

    public void Initialize()
    {
        playerWeaponSystem.SpawnDefaultWeapon();
        ApplyEXPWidget();
    }

    public void GetEXP()
    {
        curEXP += 1;
        if (curEXP >= maxEXP)
        {
            LevelUp();
            curEXP = 0;
        }

        ApplyEXPWidget();
    }

    public RectTransform hpBarValue;
    int hpBarMaxWidth = 932;

    public TextMeshProUGUI levelText;

    void ApplyEXPWidget()
    {
        float targetPer = ((float)curEXP / maxEXP) * hpBarMaxWidth;
        hpBarValue.sizeDelta = new Vector2(targetPer, 0);
        levelText.text = "Lv" + level;
    }

    void LevelUp()
    {
        level += 1;
        SelectStatusSystem.Instance.Open();


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PickUpAble")
        {
            if (collision.gameObject.name.Contains("EXPBall"))
            {
                GetEXP();
                GetComponentInChildren<PickUpRange>().pulledObjets.Remove(collision.gameObject);
                Destroy(collision.gameObject);
            }
        }
    }

    public void GetDamage()
    {

    }
}
