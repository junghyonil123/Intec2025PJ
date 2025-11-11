using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Monster : MonoBehaviour
{
    Player target;
    public NavMeshAgent navMesh;

    public int maxHp = 1;
    public int curHp; //현재체력
    bool isAlive = true;

    public int dropEXP = 3;
    public GameObject EXPBall;

    public void GetDamage(int damage)
    {
        if (!isAlive)
            return;
        
        curHp -= damage;

        if (curHp <= 0)
            Die();
    }

    void Die()
    {
        GetComponent<Animator>().SetTrigger("OnDie");
        isAlive = false;
        navMesh.isStopped = true;
        DropExpBall();
    }

    public void DestryMonster()
    {
        Destroy(gameObject);
    }

    void DropExpBall()
    {
        for (int i = 0; i < dropEXP; i++)
        {
            GameObject expBall = 
                Instantiate(EXPBall, transform.position, Quaternion.identity);

            expBall.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-2, 2)
                , 10
                , Random.Range(-2, 2)), ForceMode.Impulse); 
        }
    }


    private void Start()
    {
        target = Player.Instance;
        navMesh = GetComponent<NavMeshAgent>();

        curHp = maxHp;
    }

    private void Update()
    {
        if (isAlive)
            navMesh.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}
