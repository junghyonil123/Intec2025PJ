using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            GameObject.Find("GameManager").GetComponent<GameManager>().Clear();

    }
    public int Add(int a, int b)
    {
        return a + b;
    }
}
