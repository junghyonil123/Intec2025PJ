using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float startPos;
    [SerializeField]
    float finishPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    bool dir = true;
    void Update()
    {
        if (transform.position.x >= finishPos)
        {
            dir = false;
        }
        else if(transform.position.x <= startPos)
        {
            dir = true;
        }
        if (dir)
           transform.position += new Vector3(1,0,0) * Time.deltaTime * 3;//앞으로 이동함
        else
           transform.position -= new Vector3(1,0,0) * Time.deltaTime * 3;//반대로 이동함
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            FindAnyObjectByType<GameManager>().Respawn();
    }

}
