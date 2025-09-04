using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public Player owner;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            owner.Attack(collision.gameObject.GetComponent<Slime>());
            owner.slashRange.gameObject.SetActive(false);
        }
    }
}
