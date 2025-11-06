using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public int damage = 1;

    void Update()
    {
        transform.Rotate(Vector2.up);

        // 플레이어를 따라다님

        this.transform.position = Player.Instance.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
             other.GetComponent<Monster>().GetDamage(damage);
    }
}
