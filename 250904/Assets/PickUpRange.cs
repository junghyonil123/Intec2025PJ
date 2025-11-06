using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRange : MonoBehaviour
{
    public List<GameObject> pulledObjets;

    private void Update()
    {
        //³» ¸öÀ¸·Î²ø¾î´ç±â±â
        foreach (var item in pulledObjets)
        {
            item.GetComponent<Rigidbody>().AddForce(
                Player.Instance.transform.position - item.transform.position
                , ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other) // 
    {
        if (other.tag == "PickUpAble")
        {
            if (!pulledObjets.Contains(other.gameObject))
            {
                pulledObjets.Add(other.gameObject);
                other.GetComponent<Rigidbody>().useGravity = false;
            }
        }    
    }
}
