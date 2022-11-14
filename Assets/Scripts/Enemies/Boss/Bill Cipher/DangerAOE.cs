using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerAOE : MonoBehaviour
{
    public LayerMask player;
    public Transform target;
    public GameObject BillAOE;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        Teleport();
    }

    void Update() 
    {
        Destroy(gameObject, 2);
    }

    void Teleport()
    {
        transform.position = new Vector2(target.position.x , target.position.y);
    }

    void OnDestroy() 
    {
        GameObject AOE = Instantiate(BillAOE, gameObject.transform.position, gameObject.transform.rotation);
    }
}