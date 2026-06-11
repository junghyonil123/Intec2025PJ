using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField]
    float moveCol = 5f;

    public int level = 1;

    [SerializeField]
    List<Sprite> forms;

    private void Awake()
    {
        StartCoroutine(StartMove());
    }

    IEnumerator StartMove()
    {
        while (true)
        {
            Move();
            yield return new WaitForSecondsRealtime(Random.Range(moveCol - 1f, moveCol + 1f)); 
        }
    }

    IEnumerator StartMoveLerp(Vector3 targetPos)
    {
        float moveFrquency = 1 / Time.deltaTime; // 60;
        Vector3 moveVec = targetPos - transform.position;
        Vector3 startVec = transform.position;

        for (int i = 0; i < moveFrquency; i++)
        {
            transform.position = startVec + moveVec * (i / moveFrquency) ;
            yield return new WaitForSecondsRealtime(Time.deltaTime);
        }
    }

    void Move()
    {
        Vector3 _targetPos = new(transform.position.x + Random.Range(0.1f, 0.3f), transform.position.y + Random.Range(0.1f, 0.3f));
        StartCoroutine(StartMoveLerp(_targetPos));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Slime otherSlime;
        if (otherSlime = collision.gameObject.GetComponent<Slime>())
        {
            if (otherSlime.level == level)
            {
                Destroy(otherSlime.gameObject);
                level++;
                GetComponent<SpriteRenderer>().sprite = forms[level - 1];
                return;
            }
        }
    }


}
