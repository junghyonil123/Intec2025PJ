using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    Player target;
    public NavMeshAgent navMesh;

    private void Start()
    {
        target = Player.Instance;
        navMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMesh.SetDestination(target.transform.position);
    }
}
