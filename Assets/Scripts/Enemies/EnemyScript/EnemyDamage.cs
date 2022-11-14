using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Player currentHealth = collision.collider.GetComponent<Player>();
        if (currentHealth != null)
        {
            currentHealth.TakeDamage(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Player currentHealth = other.GetComponent<Player>();
        if (other.gameObject.tag == "Player")
        {
            currentHealth.TakeDamage(1);
            Destroy(gameObject);
        }
    }

}
