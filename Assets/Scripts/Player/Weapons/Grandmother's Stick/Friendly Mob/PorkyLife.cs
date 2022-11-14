using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorkyLife : MonoBehaviour
{
    private int lifePoint;
    private double damageTaken;

    void Start()
    {
        lifePoint = 7;
        damageTaken = 0;
    }

    void Update ()
    {
        if (damageTaken >= lifePoint)
        {
            Destroy(gameObject);
        } else {
            damageTaken += 0.014;
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStats es = collision.gameObject.GetComponent<EnemyStats>();
            damageTaken += es.damage;
        }
    }
}
