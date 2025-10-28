using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSystem : MonoBehaviour
{
    public GameObject defaultWeapon;

    public void SpawnDefaultWeapon()
    {
        GameObject obj = Instantiate(defaultWeapon, Player.Instance.transform.position, Quaternion.identity);
        obj.transform.parent = transform;
    }
}
