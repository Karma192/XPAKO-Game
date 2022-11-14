using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillShooting : MonoBehaviour
{

    public GameObject DangerAOE;
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate;
    public float speed;
    public float shootingRange;
    public float Timefixed;
    
    private float nextFireTime;
    private Transform player;
    private float timeValue = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet,bulletParent.transform.position,Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

        if (timeValue >= 0)
        {
            Timefixed = Mathf.Round(timeValue += Time.deltaTime);
        }

        if (Timefixed == 5)
        {
            Instantiate(DangerAOE,bulletParent.transform.position,Quaternion.identity);
            Timefixed = 0;
            timeValue = 0;
        }
    }
}
