using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    private int tmpLife = 10;
    private int tmp;

    void Update ()
    {
        if (tmp == tmpLife)
        {
            Destroy(gameObject);
        } else {
            tmp++;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            EnemyLifeSys ELS = collision.gameObject.GetComponent<EnemyLifeSys>();
            ELS.HLS = true;
        }

        if (collision.gameObject.name == "Rathaloose")
        {
            RathalooseLife RL = collision.gameObject.GetComponent<RathalooseLife>();
            RL.HLS = true;
        }
    }
}
