using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillTP : MonoBehaviour
{
    
    public Transform target;
    public float rotationSpeed = 0;
    public float teleportTime = 45;
    public float dist;
    public int time = 5;

    private IEnumerator BTP;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        StartCoroutine(TP(time));
    }

    void Teleport(float dist)
    {
        transform.position = new Vector2 (target.position.x + dist, target.position.y + dist);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player currentHealth = other.GetComponent<Player>();
    }

    public IEnumerator TP (int time)
    {
       Teleport(4);
       yield return new WaitForSeconds(time);
       transform.position += Random.insideUnitSphere * 5;
       yield return new WaitForSeconds(time);
       Teleport(-4);
       yield return new WaitForSeconds(time);
       transform.position += Random.insideUnitSphere * 5;
       yield return new WaitForSeconds(time);
       Teleport(3);
       yield return new WaitForSeconds(time);
       transform.position += Random.insideUnitSphere * 5;
       yield return new WaitForSeconds(time);
       Teleport(-3);
       StartCoroutine(TP(time));
    }  
}
