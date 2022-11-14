using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillAOE : MonoBehaviour
{
    public float attackRange;
    public LayerMask player;
    public Transform attackPoint;
    public Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    
    void Update()
    {
        Destroy(gameObject, 1);
    }

    void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, player);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Player currentHealth = other.GetComponent<Player>();
    }
}
