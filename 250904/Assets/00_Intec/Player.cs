using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int maxHP = 10;
    public int curHP = 10;
    public int attack = 3;
    
    private void Awake()
    {
        Instance = this;     
    }

    public void GetDamage()
    {

    }
}
