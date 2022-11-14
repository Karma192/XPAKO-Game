using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RathalooseShoot : MonoBehaviour
{
    
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate;
    public float speed;
    public float shootingRange;

    private float nextFireTime;
    private Transform player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet,bulletParent.transform.position,Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    // private void OnDrawGizmosSelected() 
    // {
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawWireSphere(transform.position, shootingRange);
    // }
}
