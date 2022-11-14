using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactuarThorn : MonoBehaviour
{
    public float speed;
    GameObject target;
    Rigidbody2D bulletRB;
    
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg + 180f;
        bulletRB.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {  
        Player currentHealth = collision.collider.GetComponent<Player>();
            
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            currentHealth.TakeDamage(2);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Player currentHealth = other.GetComponent<Player>();
        if (other.gameObject.tag == "Player")
        {
            currentHealth.TakeDamage(2);
            Destroy(gameObject);
        }
    }
}
